using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Animation
{
    /**
     * <summary>
     * A simple animation state machine which destroy a game object when the
     * animation is over.
     * </summary>
     */
    public class DestroyOnExitAnimationController : StateMachineBehaviour
    {
        # region Properties
        # endregion

        # region PropertyAccessors
        # endregion

        # region PublicMethods

        /**
         * <inheritdoc/>
         */
        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            GameObject.Destroy(animator.gameObject);
        }

        # endregion

        # region PrivateMethods
        # endregion
    }
}
