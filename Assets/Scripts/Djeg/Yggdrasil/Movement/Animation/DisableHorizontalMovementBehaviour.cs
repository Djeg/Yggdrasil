using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Djeg.Yggdrasil.Movement.Component;

namespace Djeg.Yggdrasil.Movement.Animation
{
    /**
     * <summary>
     * Disbale the ControlHorizontalMovement component during the
     * entire animation.
     * </summary>
     */
    public class DisableHorizontalMovementBehaviour : StateMachineBehaviour
    {
        # region Properties

        /**
         * <summary>
         * A reference to the ControlHorizontalMovement
         * </summary>
         */
        private ControlHorizontalMovement _movement = null;

        # endregion

        # region PropertyAccessors
        # endregion

        # region PublicMethods

        /**
         * <inheritdoc/>
         */
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            _movement = animator.GetComponent<ControlHorizontalMovement>();

            if (null == _movement)
              return;

            _movement.enabled = false;
        }

        /**
         * <inheritdoc/>
         */
        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (null == _movement)
              return;

            _movement.enabled = true;
        }

        # endregion

        # region PrivateMethods
        # endregion
    }
}
