using System;
using UnityEngine;
using Yggdrasil.Core.Controller;
using Yggdrasil.Core.Job;
using Yggdrasil.Data.Movement;

namespace Yggdrasil.Job.Aestrid
{
    /**
     * <summary>
     * Send data to the animator in order to make Aestrid run, jump,
     * attack, dash and more.
     * </summary>
     */
    [Serializable]
    public class HandleAestridAnimator : IJob
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
         * A reference to the animator
         * </summary>
         */
        private Animator _animator = null;

        /**
         * <summary>
         * A reference to the terestrial movement data
         * </summary>
         */
        private TerestrialMovement _movement = null;

        # endregion

        # region PropertyAccessors

        public JobMethod Method { get => JobMethod.Update; }

        # endregion

        # region PublicMethods

        /**
         * <inheritdoc />
         */
        public void Init(MonoController controller)
        {
            _animator = controller.GetComponent<Animator>();
            _movement = controller.GetData<TerestrialMovement>();

            UpdateAnimatorData();
        }

        /**
         * <inheritdoc />
         */
        public void Handle() => UpdateAnimatorData();

        # endregion

        # region PrivateMethods

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
        }

        # endregion
    }
}
