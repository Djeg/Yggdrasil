using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Djeg.Yggdrasil.Movement.Component;

namespace Djeg.Yggdrasil.Movement.Animation
{
    /**
     * <summary>
     * Disable the ControlJumpMovement during an animation
     * </summary>
     */
    public class DisableJumpMovementBehaviour : StateMachineBehaviour
    {
        # region Properties

        /**
         * <summary>
         * A reference to the ControlJumpMovement
         * </summary>
         */
        private ControlJumpMovement _jump = null;

        # endregion

        # region PropertyAccessors
        # endregion

        # region PublicMethods

        /**
         * <inheritdoc/>
         */
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            _jump = animator.GetComponent<ControlJumpMovement>();

            if (null == _jump)
                return;

            _jump.enabled = false;
        }

        /**
         * <inheritdoc/>
         */
        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            _jump.enabled = true;
        }

        # endregion

        # region PrivateMethods
        # endregion
    }
}
