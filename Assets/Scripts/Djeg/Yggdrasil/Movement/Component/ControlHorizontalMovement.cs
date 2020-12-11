using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using Djeg.Yggdrasil.Movement.Data;

namespace Djeg.Yggdrasil.Movement.Component
{
    /**
     * <summary>
     * This behaviour allow any game object to move horizontaly.
     * </summary>
     */
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(SpriteRenderer))]
    public class ControlHorizontalMovement : MonoBehaviour
    {
        # region Properties

        /**
         * <summary>
         * The speed of the horizontal movement
         * </summary>
         */
        [SerializeField]
        [Tooltip("The speed")]
        private float _speed = 410f;

        /**
         * <summary>
         * The 
         * </summary>
         */
        [SerializeField]
        [Tooltip("The smooth amount")]
        private float _smooth = 0.15f;

        /**
         * <summary>
         * The direction where this object is going
         * </summary>
         */
        [SerializeField]
        private HorizontalDirection _direction = HorizontalDirection.Right;

        /**
         * <summary>
         * The current movement. Must be a number between -1 for left and 1 for right.
         * </summary>
         */
        private float _currentMovement = 0f;

        /**
         * <summary>
         * Flip the sprite when changing direction
         * </summary>
         */
        [SerializeField]
        private bool _flipSprite = true;

        /**
         * <summary>
         * A reference to the Rigidbody2D attached to this game object
         * </summary>
         */
        private Rigidbody2D _body = null;

        /**
         * <summary>
         * A reference to the sprite renderer
         * </summary>
         */
        private SpriteRenderer _renderer = null;

        /**
         * <summary>
         * A reference to the velocity stored by the SmoothDamp algorithm.
         * </summary>
         */
        private Vector2 _dampVelocity = Vector2.zero;

        # endregion

        # region PropertyAccessors

        /**
         * <summary>
         * Retrieve the direction of the object
         * </summary>
         */
        public HorizontalDirection Direction { get => _direction; }

        /**
         * <summary>
         * Retrieve and set the speed
         * </summary>
         */
        public float Speed
        {
            get => _speed;
            set => _speed = value;
        }

        /**
         * <summary>
         * Retrieave and set the smooth amount
         * </summary>
         */
        public float Smooth
        {
            get => _smooth;
            set => _smooth = value;
        }

        /**
         * <summary>
         * Retrieve the flip sprite
         * </summary>
         */
        public bool FlipSprite { get => _flipSprite; }

        /**
         * <summary>
         * Retrieve and set the current movement
         * </summary>
         */
        public float CurrentMovement
        {
            get => _currentMovement;
            set => _currentMovement = value;
        }

        # endregion

        # region PublicMethods
        # endregion

        # region PrivateMethods

        /**
         * <inheritdoc/>
         */
        private void Awake()
        {
            _body     = GetComponent<Rigidbody2D>();
            _renderer = GetComponent<SpriteRenderer>();
        }

        /**
         * <inheritdoc/>
         */
        private void FixedUpdate()
        {
            float movement = _currentMovement * _speed * Time.fixedDeltaTime;
            Vector2 target = new Vector2(movement, _body.velocity.y);

            _body.velocity = Vector2.SmoothDamp(
                _body.velocity,
                target,
                ref _dampVelocity,
                _smooth
            );

            if (!_flipSprite)
                return;

            if (
                (_direction == HorizontalDirection.Right && _currentMovement < 0f)
                || (_direction == HorizontalDirection.Left && _currentMovement > 0f)
            ) {
                _renderer.flipX = !_renderer.flipX;
                _direction      = HorizontalDirectionHelper.FromFloat(
                    _currentMovement,
                    _direction
                );
            }
        }

        /**
         * <summary>
         * Handle the move input
         * </summary>
         */
        private void OnMoveInput(InputValue input)
        {
            Vector2 movement = input.Get<Vector2>();

            _currentMovement = movement.x;
        }

        # endregion
    }
}
