using System;
using UnityEngine;
using Yggdrasil.Core.Physic;

namespace Yggdrasil.Data.Movement
{
    /**
     * <summary>
     * Contains all the data to make an object move horizontaly and verticaly
     * with the ability to jump.
     * </summary>
     */
    [Serializable]
    public class TerestrialMovement
    {
        /**
         * <summary>
         * Contains the horizontal movement speed
         * </summary>
         */
        [Tooltip("The speed of the horizontal movement")]
        [Range(1f, 1000f)]
        public float speed = 450f;

        /**
         * <summary>
         * Contains the smooth time for the movement
         * </summary>
         */
        [Tooltip("The smoothing time of this character horizontal movement")]
        [Range(0f, 1f)]
        public float smoothTime = 0.2f;

        /**
         * <summary>
         * Freeze or not the movement. When frozen the movement
         * should not happen.
         * </summary>
         */
        [Tooltip("Freeze the movement or not. When freeze the object don't move.")]
        public bool isFrozen = false;

        /**
         * <summary>
         * The current movement
         * </summary>
         */
        [HideInInspector]
        public float currentMovement = 0f;

        /**
         * <summary>
         * The current direction
         * </summary>
         */
        [HideInInspector]
        public Direction direction = Direction.RIGHT;

        /**
         * <summary>
         * A velocity used to store the smooth data
         * </summary>
         */
        [HideInInspector]
        public Vector2 velocity = Vector2.zero;

        /**
         * <summary>
         * Determine the jump force
         * </summary>
         */
        [Tooltip("The jump force")]
        [Range(100f, 3000f)]
        public float jumpForce = 900f;

        /**
         * <summary>
         * Test if the object is juming
         * </summary>
         */
        [HideInInspector]
        public bool jumping = false;

        /**
         * <summary>
         * Test if the object if falling
         * </summary>
         */
        [HideInInspector]
        public bool falling = false;

        /**
         * <summary>
         * Contains the length of the ground detector raycast
         * </summary>
         */
        [Tooltip("Define the length of the raycast used to detect ground collision.")]
        [Range(0.1f, 3f)]
        public float groundRaycastLength = 1.5f;

        /**
         * <summary>
         * Contains the layers that contains the ground
         * </summary>
         */
        [Tooltip("Define the layer used for ground collision.")]
        public LayerMask groundLayer = Physics2D.AllLayers;

        /**
         * <summary>
         * Request a jump
         * </summary>
         */
        [HideInInspector]
        public bool requestJump = false;

        /**
         * <summary>
         * Test if the movement has changed direction
         * </summary>
         */
        public bool HasChangedDirection
        {
            get =>
                direction == Direction.RIGHT && currentMovement < 0f
                    ? true
                    : direction == Direction.LEFT && currentMovement > 0f
                        ? true
                        : false
            ;
        }

        /**
         * <summary>
         * Detect if the player is currently moving
         * </summary>
         */
        public bool IsMoving { get => currentMovement != 0; }
    }
}
