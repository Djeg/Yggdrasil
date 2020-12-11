using System;
using UnityEngine;
using Core;

namespace Data
{
    /**
     * <summary>
     * Contains all the data needed to make an object move
     * </summary>
     */
    [Serializable]
    public class MovementData
    {
        # region Properties

        /**
         * <summary>
         * Contains the horizontal movement speed
         * </summary>
         */
        [Header("On Ground")]
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
        [HideInInspector]
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
        public Direction direction = Direction.RIGHT;

        /**
         * <summary>
         * The current velocity
         * </summary>
         */
        [HideInInspector]
        public Vector2 currentVelocity = Vector2.zero;

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
        [Header("On Air")]
        [Tooltip("The jump force")]
        [Range(0.1f, 100f)]
        public float jumpForce = 10f;

        /**
         * <summary>
         * Determine the time allowed for maximizing jump
         * </summary>
         */
        [Tooltip("The jump time")]
        [Range(0.1f, 2f)]
        public float jumpTime = 0.25f;

        /**
         * <summary>
         * Define the drag intensity
         * </summary>
         */
        [Tooltip("The drag intensity")]
        [Range(1f, 100f)]
        public float dragIntensity = 40f;

        /**
         * <summary>
         * Define the draging jump force
         * </summary>
         */
        [Tooltip("The dragging jump force")]
        [Range(1f, 50f)]
        public float draggingJumpForce = 20f;

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
         * Contains the ltargetength of the wall detector raycase
         * </summary>
         */
        [Tooltip("Define the length of the raycast used to detect wall collision.")]
        [Range(0.1f, 3f)]
        public float wallRaycastLength = 0.5f;

        /**
         * <summary>
         * Contains the ltargetength of the wall detector raycase
         * </summary>
         */
        [Tooltip("Define the offset Y of the raycast used to detect wall collision.")]
        [Range(-3, 3f)]
        public float wallRaycastOffsetY = 0f;

        /**
         * <summary>
         * Contains the layers that contains the ground
         * </summary>
         */
        [Tooltip("Define the layer used for ground collision.")]
        public LayerMask groundLayer = Physics2D.AllLayers;

        /**
         * <summary>
         * The dashing intensity
         * </summary>
         */
        [Header("On Dash")]
        public float dashForce = 10f;

        /**
         * <summary>
         * The dashing time
         * </summary>
         */
        public float dashTime = .25f;

        /**
         * <summary>
         * Test if the character is dashing
         * </summary>
         */
        public bool dashing = false;

        /**
         * <summary>
         * Request a dash
         * </summary>
         */
        public bool requestDash = false;

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
         * Test if the object is colliding with a wall
         * </summary>
         */
        [HideInInspector]
        public bool blocking = false;

        /**
         * <summary>
         * Test if the object is dragging
         * </summary>
         */
        [HideInInspector]
        public bool dragging = false;

        /**
         * <summary>
         * Request a jump
         * </summary>
         */
        [HideInInspector]
        public bool requestJump = false;

        /**
         * <summary>
         * Does the character is holding jump
         * </summary>
         */
        [HideInInspector]
        public bool holdingJump = false;

        /**
         * <summary>
         * The jump time counter
         * </summary>
         */
        [HideInInspector]
        public float jumpTimeCounter = 0f;

        /**
         * <summary>
         * Test if the movement has changed direction
         * </summary>
         */
        public bool HasChangedDirection
        {
            get =>
                direction == Direction.RIGHT && currentVelocity.x < -0.1f
                    ? true
                    : direction == Direction.LEFT && currentVelocity.x > 0.1f
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

        # endregion

        # region PropertyAccessors
        # endregion
    }
}
