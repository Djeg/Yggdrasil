using System.Collections;
using UnityEngine;
using Yggdrasil.Component.Character;

namespace Yggdrasil.Component.Player
{
    /**
     * <summary>
     * Contains all the code executed on each update or fixed
     * update.
     * </summary>
     */
    [RequireComponent(typeof(CharacterMovement))]
    [RequireComponent(typeof(CharacterJump))]
    [RequireComponent(typeof(PlayerInput))]
    public class PlayerController : MonoBehaviour
    {
        # region Properties

        /**
         * <summary>
         * The character movement
         * </summary>
         */
        private CharacterMovement movement = null;

        /**
         * <summary>
         * The player input
         * </summary>
         */
        private PlayerInput input = null;

        /**
         * <summary>
         * The character jump component
         * </summary>
         */
        private CharacterJump jump = null;

        # endregion

        # region PropertyAccessors
        # endregion

        # region PublicMethods
        # endregion

        # region PrivateMethods

        /**
         * <summary>
         * Executed when the component is awake
         * </summary>
         */
        private void Awake()
        {
            input    = GetComponent<PlayerInput>();
            movement = GetComponent<CharacterMovement>();
            jump     = GetComponent<CharacterJump>();
        }

        /**
         * <summary>
         * Executed on each fixed update
         * </summary>
         */
        private void FixedUpdate()
        {
            movement.Move(input.horizontalMovement);

            if (input.jumping)
                jump.Jump();
        }

        # endregion
    }
}
