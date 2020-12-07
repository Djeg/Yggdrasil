using System;
using UnityEngine;
using Yggdrasil.Core.Physic;
using Yggdrasil.Core.Controller;
using Yggdrasil.Core.Job;
using Yggdrasil.Job.Movement;
using Yggdrasil.Data.Movement;

namespace Yggdrasil.Job.Movement
{
    /**
     * <summary>
     * Allow any object to move according to a TerestrialMovementData
     * </summary>
     */
    [Serializable]
    public class HandleTerestrialMovement : IGizmosJob
    {
        # region Properties
        /**
         * <summary>
         * A reference to the movement data
         * </summary>
         */
        private TerestrialMovement _movement = null;

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
         *  A reference to the current game object transform
         * </summary>
         */
        private Transform _transform = null;

        /**
         * <summary>
         * A reference to the previous position Y
         * </summary>
         */
        private float _previousY = 0f;

        # endregion

        # region PropertyAccessors

        /**
         * <inheritdoc/>
         */
        public JobMethod Method { get => JobMethod.FixedUpdate; }

        # endregion

        # region PublicMethods

        /**
         * <inheritdoc/>
         */
        public void Init(MonoController controller)
        {
            _movement = controller.GetData<TerestrialMovement>();
            _body         = controller.GetComponent<Rigidbody2D>();
            _renderer     = controller.GetComponent<SpriteRenderer>();
            _transform    = controller.gameObject.transform;
            _previousY    = controller.gameObject.transform.position.y;
        }

        /**
         * <inheritdoc/>
         */
        public void Handle()
        {
            HandleMove();
            HandleJump();
        }

        /**
         * <inheritdoc/>
         */
        public void DrawGizmos(MonoController controller)
        {
        }

        /**
         * <inheritdoc/>
         */
        public void DrawGizmosSelected(MonoController controller)
        {
            TerestrialMovement movement = controller.GetData<TerestrialMovement>();
            Transform transform = controller.gameObject.transform;

            Gizmos.color = Color.blue;

            Vector3 target = new Vector3(
                transform.position.x,
                transform.position.y - movement.groundRaycastLength,
                transform.position.z
            );

            Gizmos.DrawLine(transform.position, target);
        }

        # endregion

        # region PrivateMethods

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
                _transform.position,
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
            bool fall = _transform.position.y < _previousY;

            _previousY = _transform.position.y;

            return _movement.jumping && fall;
        }

        # endregion
    }
}
