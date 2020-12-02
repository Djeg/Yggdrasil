using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yggdrasil.Component.Character;
using Yggdrasil.Component.Player;

namespace Yggdrasil.Animation.Player
{
    /**
     * <summary>
     * Trigger when the player is iddle or running
     * </summary>
     */
    public class PlayerIdleRunBehaviour : StateMachineBehaviour
    {
        # region Properties

        /**
         * <summary>
         * The running boolean name
         * </summary>
         */
        [SerializeField]
        private string runningBooleanName = "Running";

        /**
         * <summary>
         * A reference to the player input
         * </summary>
         */
        private PlayerInput input = null;

        /**
         * <summary>
         * A reference to the character movement component
         * </summary>
         */
        private CharacterMovement movement = null;

        # endregion

        # region PropertyAccessors
        # endregion

        # region PublicMethods

        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            input = animator.gameObject.GetComponent<PlayerInput>();
            movement = animator.gameObject.GetComponent<CharacterMovement>();
        }

        override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            animator.SetBool(runningBooleanName, movement.IsMoving);
        }

        # endregion

        # region PrivateMethods
        # endregion
    }
}
