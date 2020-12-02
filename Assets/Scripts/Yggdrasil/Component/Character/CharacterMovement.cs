using System;
using System.Collections;
using UnityEngine;
using Yggdrasil.Core.Physic;
using Yggdrasil.Component.Character.Action;

namespace Yggdrasil.Component.Character
{
    /**
     * <summary>
     * This class contains all the data needed to make a character moove.
     * </summary>
     */
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
        public void Move(MoveCharacter motion)
        {
            float movement = motion.horizontalMovement * speed * Time.fixedDeltaTime;
            Vector2 target = new Vector2(
                movement,
                motion.body.velocity.y
            );


            motion.body.velocity = Vector2.SmoothDamp(
                motion.body.velocity,
                target,
                ref velocity,
                smoothTime
            );

            UpdateDirection(motion);

            moving = Math.Abs(motion.horizontalMovement) >= sensibility;
        }

        # endregion

        # region PrivateMethods

        /**
         * <summary>
         * Check if we need to update the direction
         * </summary>
         */
        private void UpdateDirection(MoveCharacter motion)
        {
            if (Math.Abs(motion.horizontalMovement) < sensibility)
                return;

            Direction newDirection = motion.horizontalMovement < sensibility
                ? Direction.LEFT
                : Direction.RIGHT
            ;

            if (newDirection == direction)
                return;

            direction = newDirection;

            motion.sprite.transform.Rotate(0f, 180f, 0f);
        }

        # endregion
    }
}
