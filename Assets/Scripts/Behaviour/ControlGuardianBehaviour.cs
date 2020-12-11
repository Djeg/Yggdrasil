using System;
using UnityEngine;
using Core;
using Data;

namespace Behaviour
{
    /**
     * <summary>
     * Contains all the methods used in order to make the guardian
     * IA.
     * </summary>
     */
    [RequireData(typeof(GuardianData))]
    [RequireData(typeof(MovementData))]
    [RequireData(typeof(CharacterStatData))]
    [RequireData(typeof(AttackCollectionData))]
    [RequireComponent(typeof(Animator))]
    public class ControlGuardianBehaviour : MonoDataBehaviour
    {
        # region Properties

        /**
         * <summary>
         * The attack animation trigger name
         * </summary>
         */
        [SerializeField]
        private string _attackAnimTriggerName = "Attack";


        /**
         * <summary>
         * The death animation trigger name
         * </summary>
         */
        [SerializeField]
        private string _deathAnimationTriggerName = "Die";

        /**
         * <summary>
         * The hurt animation trigger name
         * </summary>
         */
        [SerializeField]
        private string _hurtAnimationTriggerName = "Hurt";

        /**
         * <summary>
         * The running animation boolean name
         * </summary>
         */
        [SerializeField]
        private string _runningAnimBoolName = "Running";

        /**
         * <summary>
         * A reference of the GuardianData
         * </summary>
         */
        private GuardianData _guardian;

        /**
         * <summary>
         * A reference of the movement data
         * </summary>
         */
        private MovementData _movement;

        /**
         * <summary>
         * A reference to the character stat data
         * </summary>
         */
        private CharacterStatData _stat;

        /**
         * <summary>
         * A reference to the attack collection
         * </summary>
         */
        private AttackCollectionData _attacks;

        /**
         * <summary>
         * A reference to the animator component
         * </summary>
         */
        private Animator _animator = null;

        /**
         * <summary>
         * Contains the coordinate of the left beacon x
         * </summary>
         */
        private float _leftBeaconX = 0f;

        /**
         * <summary>
         * Contains the coordinate of the right beacon x
         * </summary>
         */
        private float _rightBeaconX = 0f;

        /**
         * <summary>
         * A reference to the initial movement speed
         * </summary>
         */
        private float _initialSpeed = 0f;

        # endregion

        # region PropertyAccessors

        /**
         * <summary>
         * Return a vector2 of the X coordinate of the beacons
         * </summary>
         */
        public Vector2 BeaconPosition
        {
            get
            {
                if (0f == _leftBeaconX)
                    _leftBeaconX = transform.position.x - _guardian.leftBeaconRange;

                if (0f == _rightBeaconX)
                    _rightBeaconX = transform.position.x + _guardian.rightBeaconRange;

                return new Vector2(_leftBeaconX, _rightBeaconX);
            }
        }

        # endregion

        # region PublicMethods
        # endregion

        # region PrivateMethods

        /**
         * <inheritdoc/>
         */
        protected override void Init(MonoDataContainer container)
        {
            _guardian     = GetData<GuardianData>();
            _movement     = GetData<MovementData>();
            _attacks      = GetData<AttackCollectionData>();
            _initialSpeed = _movement.speed;
            _animator     = GetComponent<Animator>();
            _stat         = GetData<CharacterStatData>();
        }

        /**
         * <inheritdoc/>
         */
        private void OnEnable()
        {
            _stat.onTakingDamage.AddListener(HandleHurt);
        }

        /**
         * <inheritdoc/>
         */
        private void OnDisable()
        {
            _stat.onTakingDamage.RemoveListener(HandleHurt);
        }

        /**
         * <inheritdoc/>
         */
        private void Update()
        {
            if (_stat.IsDead)
                return;

            UpdateEnemiesInVision();
            UpdateEnemiesInAttackRange();
            UpdateMovement();
            UpdateAnimator();
        }

        /**
         * <summary>
         * Update the guardian movement
         * </summary>
         */
        private void UpdateMovement()
        {
            Vector2 beacons   = BeaconPosition;
            float leftBeacon  = beacons.x;
            float rightBeacon = beacons.y;
            float movement    = DirectionHelper.ToFloat(_movement.direction);
            _movement.speed   = _guardian.hasEnemiesInVision
                ? _guardian.runningSpeed
                : _initialSpeed
            ;

            if (_guardian.hasEnemiesInVision)
                return;

            if (_movement.direction == Direction.LEFT && transform.position.x <= leftBeacon)
                movement = DirectionHelper.ToFloat(Direction.RIGHT);

            if (_movement.direction == Direction.RIGHT && transform.position.x >= rightBeacon)
                movement = DirectionHelper.ToFloat(Direction.LEFT);

            _movement.currentMovement = movement;
        }

        /**
         * <summary>
         * Update the enemies in vision boolean
         * </summary>
         */
        private void UpdateEnemiesInVision()
        {
            RaycastHit2D hit = Physics2D.Raycast(
                transform.position,
                DirectionHelper.ToVector2(_movement.direction),
                _guardian.visionRange,
                _attacks.layer
            );

            _guardian.hasEnemiesInVision = hit.collider != null;
        }

        /**
         * <summary>
         * Update the enemies in attackRange boolean
         * </summary>
         */
        private void UpdateEnemiesInAttackRange()
        {
            RaycastHit2D hit = Physics2D.Raycast(
                transform.position,
                DirectionHelper.ToVector2(_movement.direction),
                _guardian.attackRange,
                _attacks.layer
            );

            _guardian.hasEnemiesInAttackRange = hit.collider != null;
            _attacks.requestHit = true;
        }

        /**
         * <summary>
         * Update the animator
         * </summary>
         */
        private void UpdateAnimator()
        {
            if (_guardian.hasEnemiesInAttackRange && _attacks.IsTriggered)
                _animator.SetTrigger(_attackAnimTriggerName);

            _animator.SetBool(_runningAnimBoolName, _guardian.hasEnemiesInVision);
        }

        /**
         * <inheritdoc/>
         */
        private void OnDrawGizmosSelected()
        {
            _guardian = GetData<GuardianData>();
            _movement = GetData<MovementData>();

            if (!_guardian.debug)
                return;

            DrawVisionRange();
            DrawBeacons();
            DrawAttackRange();
        }

        /**
         * <summary>
         * Draw the vision range
         * </summary>
         */
        private void DrawVisionRange()
        {
            Gizmos.color = Color.yellow;

            Gizmos.DrawLine(
                transform.position,
                GetVisionRangeTarget()
            );
        }

        /**
         * <summary>
         * Draw the beacons
         * </summary>
         */
        private void DrawBeacons()
        {
            Gizmos.color = Color.blue;
            Vector3 center = new Vector3(
                transform.position.x - _guardian.leftBeaconRange,
                transform.position.y - .25f,
                transform.position.z
            );

            Gizmos.DrawSphere(
                center,
                .25f
            );

            // Draw the right beacon
            Vector3 center2 = new Vector3(
                transform.position.x + _guardian.rightBeaconRange,
                transform.position.y - .25f,
                transform.position.z
            );

            Gizmos.DrawSphere(
                center2,
                .25f
            );
        }

        /**
         * <summary>
         * Draw the attackRange
         * </summary>
         */
        private void DrawAttackRange()
        {
            Gizmos.color = Color.red;

            Gizmos.DrawLine(
                transform.position,
                GetAttackRangeTarget()
            );
        }

        /**
         * <summary>
         * Get the vision range target
         * </summary>
         */
        public Vector3 GetVisionRangeTarget() =>
            new Vector3(
                transform.position.x + GetVisionRange(),
                transform.position.y,
                transform.position.z
            );

        /**
         * <summary>
         * Get the attack range target
         * </summary>
         */
        private Vector3 GetAttackRangeTarget() =>
            new Vector3(
                transform.position.x + GetAttackRange(),
                transform.position.y - .5f,
                transform.position.z
            );

        /**
         * <summary>
         * Get the attack range base on the current movement direction
         * </summary>
         */
        private float GetAttackRange() =>
            _movement.direction == Direction.LEFT
                ? -_guardian.attackRange
                : _guardian.attackRange
            ;

        /**
         * <summary>
         * Get the vision range base on the current movement direction
         * </summary>
         */
        private float GetVisionRange() =>
            _movement.direction == Direction.LEFT
                ? -_guardian.visionRange
                : _guardian.visionRange
            ;

        /**
         * <summary>
         * Handle hurt
         * </summary>
         */
        private void HandleHurt(GameObject victim, CharacterStatData.Damage damage)
        {
            if (_stat.IsDead)
                _animator.SetTrigger(_deathAnimationTriggerName);
            else
                _animator.SetTrigger(_hurtAnimationTriggerName);
        }

        # endregion
    }
}
