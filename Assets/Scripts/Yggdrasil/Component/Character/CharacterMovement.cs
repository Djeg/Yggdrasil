using System;
using System.Collections;
using UnityEngine;
using Yggdrasil.Core.Physic;

namespace Yggdrasil.Component.Character
{
    /**
     * <summary>
     * This class contains all the data needed to make a character moove.
     * </summary>
     */
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(SpriteRenderer))]
    public class CharacterMovement : MonoBehaviour
    {
        # region Properties

        /**
         * <summary>
         * The character moovement speed
         * </summary>
         */
        [Header("Horizontal movement parameters")]
        public float speed = 300f;

        /**
         * <summary>
         * The character movement smooth time
         * </summary>
         */
        public float smoothTime = .25f;

        /**
         * <summary>
         * The character current velocity
         * </summary>
         */
        public Vector2 velocity = Vector2.zero;

        /**
         * <summary>
         * Contains the current direction of the character
         * </summary>
         */
        public Direction direction = Direction.RIGHT;

        /**
         * <summary>
         * The axis sensibility. Allows the sprite to flip if needed
         * </summary>
         */
        public float sensibility = 0.2f;

        /**
         * <summary>
         * Test if the character is mooving
         * </summary>
         */
        private bool moving = false;

        /**
         * <summary>
         * The rigidbody component attached to this gameObject
         * </summary>
         */
        private Rigidbody2D body = null;

        /**
         * <summary>
         * The sprite renderer component attached to this GameObject
         * </summary>
         */
        private SpriteRenderer sprite = null;

        # endregion

        # region PropertyAccessors

        /**
         * <summary>
         * Is the character mooving
         * </summary>
         */
        public bool IsMoving { get => moving; }

        # endregion

        # region PublicMethods

        /**
         * <summary>
         * Move a character according to the given amount.
         * </summary>
         */
        public void Move(float horizontalMovement)
        {
            float movement = horizontalMovement * speed * Time.fixedDeltaTime;
            Vector2 target = new Vector2(
                movement,
                body.velocity.y
            );


            body.velocity = Vector2.SmoothDamp(
                body.velocity,
                target,
                ref velocity,
                smoothTime
            );

            UpdateDirection(horizontalMovement);

            moving = Math.Abs(horizontalMovement) >= sensibility;
        }

        # endregion

        # region PrivateMethods

        /**
         * <summary>
         * Awake
         * </summary>
         */
        private void Awake()
        {
            body   = GetComponent<Rigidbody2D>();
            sprite = GetComponent<SpriteRenderer>();
        }

        /**
         * <summary>
         * Check if we need to update the direction
         * </summary>
         */
        private void UpdateDirection(float horizontalMovement)
        {
            if (Math.Abs(horizontalMovement) < sensibility)
                return;

            Direction newDirection = horizontalMovement < sensibility
                ? Direction.LEFT
                : Direction.RIGHT
            ;

            if (newDirection == direction)
                return;

            direction = newDirection;

            sprite.transform.Rotate(0f, 180f, 0f);
        }

        # endregion
    }
}
