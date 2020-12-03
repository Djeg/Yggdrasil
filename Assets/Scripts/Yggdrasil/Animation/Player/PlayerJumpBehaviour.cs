using Yggdrasil.Component.Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yggdrasil.Animation.Player
{
    /**
     * <summary>
     * Handle the jumping animation
     * </summary>
     */
    public class PlayerJumpBehaviour : StateMachineBehaviour
    {
        # region Properties

        /**
         * <summary>
         * The jumping boolean name
         * </summary>
         */
        [SerializeField]
        private string jumpingBooleanName = "Jumping";

        /**
         * <summary>
         * The falling boolean name
         * </summary>
         */
        [SerializeField]
        private string fallingBooleanName = "Falling";

        /**
         * <summary>
         * A reference to the character jump
         * </summary>
         */
        private CharacterJump jump = null;

        # endregion

        # region PropertyAccessors
        # endregion

        # region PublicMethods

        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            jump = animator.gameObject.GetComponent<CharacterJump>();

            UpdateBooleans(animator);
        }

        override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            UpdateBooleans(animator);
        }

        /**
         * <summary>
         * Update the booleans
         * </summary>
         */
        private void UpdateBooleans(Animator animator)
        {
            animator.SetBool(jumpingBooleanName, jump.jumping);
            animator.SetBool(fallingBooleanName, jump.falling);
        }

        # endregion

        # region PrivateMethods
        # endregion
    }
}
