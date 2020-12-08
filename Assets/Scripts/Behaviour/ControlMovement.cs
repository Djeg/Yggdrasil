using System;
using UnityEngine;
using Core;
using Data;

namespace Behaviour
{
    /**
     * <summary>
     * Control the movement based on the MovementData
     * </summary>
     */
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireData(typeof(MovementData))]
    public class ControlMovement : MonoDataBehaviour
    {
        # region Properties

        /**
         * <summary>
         * A reference to the movement data
         * </summary>
         */
        private MovementData _movement = null;

        /**
         * <summary>
         * A reference to the rigidbody2D
         * </summary>
         */
        private Rigidbody2D _body = null;

        /**
         * <summary>
         * A reference to the sprite renderer used to rotate the sprite
         * when changing direction.
         * </summary>
         */
        private SpriteRenderer _renderer = null;

        /**
         * <summary>
         * A reference to the previous position Y
         * </summary>
         */
        private float _previousY = 0f;

        # endregion

        # region PropertyAccessors
        # endregion

        # region PublicMethods

        /**
         * <summary>
         * Freeze the movement
         * </summary>
         */
        public void FreezeMovement()
        {
            _movement.isFrozen = true;
        }

        /**
         * <summary>
         * Unfreeze the movement
         * </summary>
         */
        public void UnfreezeMovement()
        {
            _movement.isFrozen = false;
        }

        # endregion

        # region PrivateMethods

        /**
         * <inheritdoc/>
         */
        protected override void Init(MonoDataContainer container)
        {
            _movement  = GetData<MovementData>();
            _body      = GetComponent<Rigidbody2D>();
            _renderer  = GetComponent<SpriteRenderer>();
            _previousY = gameObject.transform.position.y;
        }

        /**
         * <inheritdoc/>
         */
        private void FixedUpdate()
        {
            HandleMove();
            HandleJump();
        }

        /**
         * <inheritdoc/>
         */
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.blue;

            Vector3 target = new Vector3(
                transform.position.x,
                transform.position.y - _movement.groundRaycastLength,
                transform.position.z
            );

            Gizmos.DrawLine(transform.position, target);
        }

        /**
         * <summary>
         * Handle the movement
         * </summary>
         */
        private void HandleMove()
        {
            if (_movement.isFrozen)
            {
                // We disable any movement when the data are frozen
                _body.velocity = Vector2.SmoothDamp(
                    _body.velocity,
                    Vector2.zero,
                    ref _movement.velocity,
                    _movement.smoothTime
                );

                return;
            }

            // We move the player
            float movement = _movement.currentMovement * _movement.speed * Time.fixedDeltaTime;
            Vector2 target = new Vector2(movement, _body.velocity.y);

            _body.velocity = Vector2.SmoothDamp(
                _body.velocity,
                target,
                ref _movement.velocity,
                _movement.smoothTime
            );

            // we update the direction
            if (_movement.HasChangedDirection)
            {
                _movement.direction = DirectionHelper.Inverse(_movement.direction);
                _renderer.transform.Rotate(0f, 180f, 0f);
            }
        }

        /**
         * <summary>
         * Handle Jump
         * </summary>
         */
        private void HandleJump()
        {
            _movement.jumping = IsJumping();
            _movement.falling = IsFalling();

            if (_movement.isFrozen)
                return;

            if (_movement.requestJump && !_movement.jumping)
                _body.AddForce(Vector2.up * _movement.jumpForce);

            _movement.requestJump = false;
        }

        /**
         * <summary>
         * Detect of the object is jumping
         * </summary>
         */
        private bool IsJumping()
        {
            RaycastHit2D hit = Physics2D.Raycast(
                transform.position,
                Vector2.down,
                _movement.groundRaycastLength,
                _movement.groundLayer
            );

            return null == hit.collider;
        }

        /**
         * <summary>
         * Detect if the object if falling
         * </summary>
         */
        private bool IsFalling()
        {
            bool fall = transform.position.y < _previousY;

            _previousY = transform.position.y;

            return _movement.jumping && fall;
        }

        # endregion
    }
}
