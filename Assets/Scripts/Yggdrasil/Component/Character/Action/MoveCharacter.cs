using System.Collections;
using UnityEngine;

namespace Yggdrasil.Component.Character.Action
{
    /**
     * <summary>
     * A simple struct grouping every data needed to move a character.
     * </summary>
     */
    public struct MoveCharacter
    {
        /**
         * <summary>
         * The horizontal movement
         * </summary>
         */
        public float horizontalMovement;

        /**
         * <summary>
         * The rigidbody 2D
         * </summary>
         */
        public Rigidbody2D body;

        /**
         * <summary>
         * The sprite renderer
         * </summary>
         */
        public SpriteRenderer sprite;
    }
}
