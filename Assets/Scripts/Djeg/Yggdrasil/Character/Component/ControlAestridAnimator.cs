using System.Collections;
using UnityEngine;
using Djeg.Yggdrasil.Movement.Component;

namespace Djeg.Yggdrasil.Character.Component
{
    /**
     * <summary>
     * Control Aestrid animator based on various event.
     * </summary>
     */
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(ControlHorizontalMovement))]
    [RequireComponent(typeof(ControlJumpMovement))]
    [RequireComponent(typeof(ControlAttackMovement))]
    public class ControlAestridAnimator : MonoBehaviour
    {
        # region Properties

        /**
         * <summary>
         * The movement float parameter name
         * </summary>
         */
        [SerializeField]
        private string _movementParameterName = "Movement";

        /**
         * <summary>
         * The running bool parameter name
         * </summary>
         */
        [SerializeField]
        private string _runningParameterName = "Running";

        /**
         * <summary>
         * The jumping parameter name
         * </summary>
         */
        [SerializeField]
        private string _jumpingParameterName = "Jumping";

        /**
         * <summary>
         * The falling parameter name
         * </summary>
         */
        [SerializeField]
        private string _fallingParameterName = "Falling";

        /**
         * <summary>
         * The attack trigger name
         * </summary>
         */
        [SerializeField]
        private string _attackParameterName = "Attack";

        /**
         * <summary>
         * The attacking parameter name
         * </summary>
         */
        [SerializeField]
        private string _attackingParameterName = "Attacking";

        /**
         * <summary>
         * Teh dashing parameter name
         * </summary>
         */
        [SerializeField]
        private string _dashingParameterName = "Dashing";

        /**
         * <summary>
         * A reference to the animator
         * </summary>
         */
        private Animator _animator = null;

        /**
         * <summary>
         * A reference to the ControlHorizontalMovement
         * </summary>
         */
        private ControlHorizontalMovement _movement = null;

        /**
         * <summary>
         * A reference to the ControlJumpMovement
         * </summary>
         */
        private ControlJumpMovement _jump = null;

        /**
         * <summary>
         * A reference to the ControlAttackMovement
         * </summary>
         */
        private ControlAttackMovement _attack = null;

        # endregion

        # region PropertyAccessors
        # endregion

        # region PublicMethods
        # endregion

        # region PrivateMethods

        /**
         * <inheritdoc/>
         */
        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _movement = GetComponent<ControlHorizontalMovement>();
            _jump     = GetComponent<ControlJumpMovement>();
            _attack   = GetComponent<ControlAttackMovement>();
        }

        /**
         * <inheritdoc/>
         */
        private void OnEnable()
        {
            _movement.OnMove.AddListener(HandleMove);

            _jump.OnRise.AddListener(HandleJumpStart);
            _jump.OnFall.AddListener(HandleJumpFall);
            _jump.OnLand.AddListener(HandleJumpLand);

            _attack.OnAttackStart.AddListener(TriggerAttack);
        }

        /**
         * <inheritdoc/>
         */
        private void OnDisable()
        {
            _movement.OnMove.RemoveListener(HandleMove);

            _jump.OnRise.RemoveListener(HandleJumpStart);
            _jump.OnFall.RemoveListener(HandleJumpFall);
            _jump.OnLand.RemoveListener(HandleJumpLand);

            _attack.OnAttackStart.RemoveListener(TriggerAttack);
        }

        /**
         * <summary>
         * Handle the move event
         * </summary>
         */
        private void HandleMove()
        {
            _animator.SetFloat(_movementParameterName, Mathf.Abs(_movement.CurrentMovement));

            _animator.SetBool(
                _runningParameterName,
                _movement.State != ControlHorizontalMovement.MovementState.Idle
            );
        }

        /**
         * <summary>
         * Handle a jump start
         * </summary>
         */
        private void HandleJumpStart()
        {
            _animator.SetBool(_jumpingParameterName, true);
            _animator.SetBool(_fallingParameterName, false);
        }

        /**
         * <summary>
         * Handle jump fall
         * </summary>
         */
        private void HandleJumpFall() => _animator.SetBool(_fallingParameterName, true);

        /**
         * <summary>
         * Handle jump land
         * </summary>
         */
        private void HandleJumpLand()
        {
            _animator.SetBool(_jumpingParameterName, false);
            _animator.SetBool(_fallingParameterName, false);
        }

        /**
         * <summary>
         * Trigger the attack animation
         * </summary>
         */
        private void TriggerAttack() => _animator.SetTrigger(_attackParameterName);

        # endregion
    }
}
