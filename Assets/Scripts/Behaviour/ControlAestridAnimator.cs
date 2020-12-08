using System;
using UnityEngine;
using Core;
using Data;

namespace Behaviour
{
    /**
     * <summary>
     * Control the animator of Aestrid by sending data issues from
     * data object.
     * </summary>
     */
    [RequireComponent(typeof(Animator))]
    [RequireData(typeof(MovementData))]
    [RequireData(typeof(AttackCollectionData))]
    public class ControlAestridAnimator : MonoDataBehaviour
    {
        # region Properties

        /**
         * <summary>
         * The animator horizontal movement float name
         * </summary>
         */
        [SerializeField]
        private string _horizontalMovementFloatName = "HorizontalMovement";

        /**
         * <summary>
         * The animator jumping boolean name
         * </summary>
         */
        [SerializeField]
        private string _jumpingBooleanName = "Jumping";

        /**
         * <summary>
         * The animator falling boolean name
         * </summary>
         */
        [SerializeField]
        private string _fallingBooleanName = "Falling";

        /**
         * <summary>
         * The animator attack trigger name
         * </summary>
         */
        [SerializeField]
        private string _attackTriggerName = "Attack";

        /**
         * <summary>
         * The animator is attackign bool name
         * </summary>
         */
        [SerializeField]
        private string _isAttackingBoolName = "Attacking";

        /**
         * <summary>
         * A reference to the animator
         * </summary>
         */
        private Animator _animator = null;

        /**
         * <summary>
         * A reference to the terestrial movement data
         * </summary>
         */
        private MovementData _movement = null;

        /**
         * <summary>
         * A reference to the hit box collection data
         * </summary>
         */
        private AttackCollectionData _attacks = null;

        # endregion

        # region PropertyAccessors
        # endregion

        # region PublicMethods

        /**
         * <summary>
         * Disable is attacking boolean
         * </summary>
         */
        public void DisableAttackingAnimation()
        {
            _animator.SetBool(_isAttackingBoolName, false);
        }

        # endregion

        # region PrivateMethods

        /**
         * <inheritdoc/>
         */
        protected override void Init(MonoDataContainer container)
        {
            _animator = GetComponent<Animator>();
            _movement = GetData<MovementData>();
            _attacks  = GetData<AttackCollectionData>();

            UpdateAnimatorData();
        }

        /**
         * <inheritdoc/>
         */
        private void Update() => UpdateAnimatorData();

        /**
         * <summary>
         * Update the animator data
         * </summary>
         */
        private void UpdateAnimatorData()
        {
            // Send the horizontal movement to the animator in order to make
            // Aestrid run, walk and idle.
            _animator.SetFloat(
                _horizontalMovementFloatName,
                Mathf.Abs(_movement.currentMovement)
            );

            // Send the jumping boolean in order to make Aestrid jump
            _animator.SetBool(
                _jumpingBooleanName,
                _movement.jumping
            );

            // Send the falling boolean in order to make Aestrid fall
            _animator.SetBool(
                _fallingBooleanName,
                _movement.falling
            );

            if (_attacks.IsTriggered)
            {
                _animator.SetTrigger(_attackTriggerName);
            }
        }

        # endregion
    }
}
