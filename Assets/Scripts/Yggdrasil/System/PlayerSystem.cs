using System.Collections;
using UnityEngine;
using Yggdrasil.Component.Player;
using Yggdrasil.Component.Character;
using CharacterAction = Yggdrasil.Component.Character.Action;

namespace Yggdrasil.System
{
    /**
     * <summary>
     * Contains all the code executed on each update or fixed
     * update.
     * </summary>
     */
    [RequireComponent(typeof(CharacterMovement))]
    [RequireComponent(typeof(PlayerInput))]
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(SpriteRenderer))]
    public class PlayerSystem : MonoBehaviour
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
         * The rigidbody 2D
         * </summary>
         */
        private Rigidbody2D body = null;

        /**
         * <summary>
         * The sprite renderer
         * </summary>
         */
        private SpriteRenderer sprite = null;

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
            body     = GetComponent<Rigidbody2D>();
            sprite   = GetComponent<SpriteRenderer>();
        }

        /**
         * <summary>
         * Executed on each update
         * </summary>
         */
        private void Update()
        {
            input.Refresh();
        }

        /**
         * <summary>
         * Executed on each fixed update
         * </summary>
         */
        private void FixedUpdate()
        {
            movement.Move(new CharacterAction.MoveCharacter {
                horizontalMovement = input.horizontalMovement,
                body = body,
                sprite = sprite
            });
        }

        # endregion
    }
}
