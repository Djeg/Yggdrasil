using System;
using System.Collections;
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
            HandleData();
            HandleMove();
            HandleJump();
            HandleDirection();
            HandleDash();
        }

        /**
         * <summary>
         * Handle the data of the movement data
         * </summary>
         */
        private void HandleData()
        {
            _movement.currentVelocity = _body.velocity;
            _movement.jumping         = IsJumping();
            _movement.falling         = IsFalling();
            _movement.blocking        = IsBlocking();
            _movement.dragging        = _movement.falling && _movement.blocking;
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
        }

        /**
         * <summary>
         * Handle Jump
         * </summary>
         */
        private void HandleJump()
        {
            _body.drag = _movement.dragging ? _movement.dragIntensity : 0f;

            if (_movement.isFrozen)
                return;

            if (_movement.jumping && !_movement.requestJump && _movement.holdingJump)
            {
                if (_movement.jumpTimeCounter > 0)
                {
                    _body.velocity = new Vector3(
                        _body.velocity.x,
                        1 * _movement.jumpForce
                    );

                    _movement.jumpTimeCounter -= Time.deltaTime;
                }
            }

            if (_movement.requestJump && !_movement.jumping)
            {
                _body.velocity = new Vector3(
                    _body.velocity.x,
                    1 * _movement.jumpForce
                );

                _movement.requestJump = false;
                _movement.jumpTimeCounter = _movement.jumpTime;
            }

            if (_movement.requestJump && _movement.blocking && _movement.jumping)
            {
                Direction inverse = DirectionHelper.Inverse(_movement.direction);

                float force = 1 * DirectionHelper.ParseFloat(
                    inverse,
                    _movement.draggingJumpForce
                );

                _body.velocity = new Vector3(
                    force,
                    1 * _movement.jumpForce
                );

                _movement.requestJump = false;
                _movement.jumpTimeCounter = _movement.jumpTime;
            }
        }

        /**
         * <summary>
         * Handle the direction
         * </summary>
         */
        private void HandleDirection()
        {
            if (!_movement.HasChangedDirection)
                return;

            _movement.direction = DirectionHelper.Inverse(_movement.direction);
            _renderer.flipX = !_renderer.flipX;
        }
        
        /**
         * <summary>
         * Handle dash
         * </summary>
         */
        private void HandleDash()
        {
            if (!_movement.requestDash)
                return;

            _movement.requestDash = false;

            StartCoroutine(Dash());
        }

        /**
         * <summary>
         * Dash the object
         * </summary>
         */
        private IEnumerator Dash()
        {
            _movement.dashing = true;
            _movement.isFrozen = true;

            Vector2 force = DirectionHelper.ToVector2(_movement.direction) * _movement.dashForce;

            _body.AddForce(force, ForceMode2D.Impulse);

            yield return new WaitForSeconds(_movement.dashTime);

            _movement.dashing = false;
            _movement.isFrozen = false;
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
         * Test if the object is blocking on a wall
         * </summary>
         */
        private bool IsBlocking()
        {
            Vector2 position = new Vector2(
                transform.position.x,
                transform.position.y + _movement.wallRaycastOffsetY
            );

            RaycastHit2D hit = Physics2D.Raycast(
                position,
                DirectionHelper.ToVector2(_movement.direction),
                _movement.wallRaycastLength,
                _movement.groundLayer
            );

            return null != hit.collider;
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

        /**
         * <inheritdoc/>
         */
        private void OnDrawGizmosSelected()
        {
            MovementData movement = GetData<MovementData>();

            if (null == movement)
                return;

            Gizmos.color          = Color.blue;
            Vector3 groundTarget = new Vector3(
                transform.position.x,
                transform.position.y - movement.groundRaycastLength,
                transform.position.z
            );
            Vector3 wallTarget = new Vector3(
                transform.position.x + DirectionHelper.ParseFloat(movement.direction, movement.wallRaycastLength),
                transform.position.y + movement.wallRaycastOffsetY,
                transform.position.z
            );
            Vector3 alteredPosition = new Vector3(
                transform.position.x,
                transform.position.y + movement.wallRaycastOffsetY,
                transform.position.z
            );

            Gizmos.DrawLine(transform.position, groundTarget);
            Gizmos.DrawLine(alteredPosition, wallTarget);
        }

        # endregion
    }
}
