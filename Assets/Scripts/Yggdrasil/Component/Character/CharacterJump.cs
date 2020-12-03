using System;
using System.Collections;
using UnityEngine;

namespace Yggdrasil.Component.Character
{
    /**
     * <summary>
     * Addthe ability to jump
     * </summary>
     */
    [RequireComponent(typeof(Rigidbody2D))]
    public class CharacterJump : MonoBehaviour
    {
        # region Properties

        /**
         * <summary>
         * The jump force
         * </summary>
         */
        public float force = 30f;

        /**
         * <summary>
         * Allows this component to detect the ground
         * </summary>
         */
        public GameObject detector = null;

        /**
         * <summary>
         * The ground layer
         * </summary>
         */
        public LayerMask layer = Physics2D.AllLayers;

        /**
         * <summary>
         * The ground detection boolean
         * </summary>
         */
        public bool jumping = false;

        /**
         * <summary>
         * Test if the character is currently fallen
         * </summary>
         */
        public bool falling = false;

        /**
         * <summary>
         * The rigidbody attached to this game object
         * </summary>
         */
        private Rigidbody2D body = null;

        /**
         * <summary>
         * A reference to the previous body transform
         * </summary>
         */
        private Vector2 previousPosition = Vector2.zero;

        # endregion

        # region PropertyAccessors
        # endregion

        # region PublicMethods

        /**
         * <summary>
         * Make the character jump
         * </summary>
         */
        public void Jump()
        {
            if (jumping)
                return;

            Vector2 f = Vector2.up * force;

            body.AddForce(f);

            jumping = true;
        }

        # endregion

        # region PrivateMethods

        /**
         * <summary>
         * When awake
         * </summary>
         */
        private void Awake()
        {
            body = GetComponent<Rigidbody2D>();
            previousPosition = gameObject.transform.position;
        }

        /**
         * <summary>
         * On fixed update
         * </summary>
         */
        private void FixedUpdate()
        {
            DetectJumping();
            DetectFalling();
        }

        /**
         * <summary>
         * Detect of the character is jumping
         * </summary>
         */
        private void DetectJumping()
        {
            Collider2D[] colliders = Physics2D.OverlapPointAll(
                detector.transform.position,
                layer
            );

            jumping = colliders.Length <= 0;
        }

        /**
         * <summary>
         * Detect if the player is falling
         * </summary>
         */
        private void DetectFalling()
        {
            falling = jumping && gameObject.transform.position.y < previousPosition.y;
            previousPosition = gameObject.transform.position;
        }

        # endregion
    }
}
