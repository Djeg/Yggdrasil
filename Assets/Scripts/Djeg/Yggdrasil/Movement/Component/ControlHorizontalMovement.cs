using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
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
         * Contains all the diferent state of an horizontal movement.
         * </summary>
         */
        public enum MovementState
        {
            Idle,
            Walk,
            Run
        }

        /**
         * <summary>
         * The speed of the horizontal movement
         * </summary>
         */
        [SerializeField]
        [Header("Parameters")]
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
         * The idle limit
         * </summary>
         */
        [SerializeField]
        [Range(0f, 1f)]
        private float _idleLimit = 0.1f;

        /**
         * <summary>
         * Walking limit
         * </summary>
         */
        [SerializeField]
        [Range(0f, 1f)]
        private float _walkLimit = 0.3f;

        /**
         * <summary>
         * The direction where this object is going
         * </summary>
         */
        [SerializeField]
        private HorizontalDirection _direction = HorizontalDirection.Right;

        /**
         * <summary>
         * Flip the sprite when changing direction
         * </summary>
         */
        [SerializeField]
        private bool _flipSprite = true;

        /**
         * <summary>
         * Attach events when this object change direction
         * </summary>
         */
        [SerializeField]
        [Header("Events")]
        private OnDirectionChangedEvent _onDirectionChanged = new OnDirectionChangedEvent();

        /**
         * <summary>
         * When the object is idling
         * </summary>
         */
        [SerializeField]
        private OnIdleEvent _onIdle = new OnIdleEvent();

        /**
         * <summary>
         * When the object is walking
         * </summary>
         */
        [SerializeField]
        private OnWalkEvent _onWalk = new OnWalkEvent();

        /**
         * <summary>
         * When the object is running
         * </summary>
         */
        [SerializeField]
        private OnRunEvent _onRun = new OnRunEvent();

        /**
         * <summary>
         * Dispatched on each frame when this object is not idle
         * </summary>
         */
        [SerializeField]
        private OnMoveEvent _onMove = new OnMoveEvent();

        /**
         * <summary>
         * The current movement. Must be a number between -1 for left and 1 for right.
         * </summary>
         */
        private float _currentMovement = 0f;

        /**
         * <summary>
         * The current state
         * </summary>
         */
        private MovementState _state = MovementState.Idle;

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

        /**
         * <summary>
         * Retrieve the current movement state
         * </summary>
         */
        public MovementState State { get => _state; }

        /**
         * <summary>
         * Retrieve the OnDirectionChanged event
         * </summary>
         */
        public OnDirectionChangedEvent OnDirectionChanged { get => _onDirectionChanged; }

        /**
         * <summary>
         * Retrieve the OnIdleEvent event
         * </summary>
         */
        public OnIdleEvent OnIdle { get => _onIdle; }

        /**
         * <summary>
         * Retrieve OnWalkEvent
         * </summary>
         */
        public OnWalkEvent OnWalk { get => _onWalk; }

        /**
         * <summary>
         * Get the OnRunEvent
         * </summary>
         */
        public OnRunEvent OnRun { get => _onRun; }

        /**
         * <summary>
         * Get the OnMoveEvent
         * </summary>
         */
        public OnMoveEvent OnMove { get => _onMove; }

        # endregion

        # region PublicMethods

        /**
         * <summary>
         * Request a direction changement
         * </summary>
         */
        public void FlipDirection()
        {
            HorizontalDirection oldDirection = _direction;
            _direction = HorizontalDirectionHelper.Inverse(_direction);

            _renderer.flipX = !_renderer.flipX;

            OnDirectionChanged.Invoke(oldDirection, _direction);
        }

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
            UpdateVelocity();
            UpdateDirection();
            UpdateMovementState();
            InvokeOnMove();
        }

        /**
         * <summary>
         * Invoke on move event if the state isn't idle
         * </summary>
         */
        private void InvokeOnMove() => OnMove.Invoke();

        /**
         * <summary>
         * Update the body velocity
         * </summary>
         */
        private void UpdateVelocity()
        {
            float movement = _currentMovement * _speed * Time.deltaTime;
            Vector2 target = new Vector2(movement, _body.velocity.y);

            _body.velocity = Vector2.SmoothDamp(
                _body.velocity,
                target,
                ref _dampVelocity,
                _smooth
            );
        }

        /**
         * <summary>
         * Update the direction
         * </summary>
         */
        private void UpdateDirection()
        {
            if (
                (_direction == HorizontalDirection.Right && _currentMovement < 0f)
                || (_direction == HorizontalDirection.Left && _currentMovement > 0f)
            ) {
                HorizontalDirection oldDirection = _direction;

                if (_flipSprite)
                    _renderer.flipX = !_renderer.flipX;

                _direction = HorizontalDirectionHelper.FromFloat(
                    _currentMovement,
                    _direction
                );

                OnDirectionChanged.Invoke(oldDirection, _direction);
            }
        }

        /**
         * <summary>
         * Update the movement state
         * </summary>
         */
        private void UpdateMovementState()
        {
            float movement = Mathf.Abs(_currentMovement);

            if (movement < _idleLimit && _state != MovementState.Idle)
            {
                _state = MovementState.Idle;

                OnIdle.Invoke();

                return;
            }

            if (movement >= _idleLimit && movement < _walkLimit && _state != MovementState.Walk)
            {
                _state = MovementState.Walk;

                OnWalk.Invoke();

                return;
            }

            if (movement >= _walkLimit && _state != MovementState.Run)
            {
                _state = MovementState.Run;

                OnRun.Invoke();

                return;
            }
        }

        /**
         * <inheritdoc/>
         */
        private void OnDisable()
        {
            _body.velocity = new Vector2(0, _body.velocity.y);
            _dampVelocity = Vector2.zero;
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

    [Serializable]
    public sealed class OnDirectionChangedEvent : UnityEvent<HorizontalDirection, HorizontalDirection>
    {
    }

    [Serializable]
    public sealed class OnIdleEvent : UnityEvent
    {
    }

    [Serializable]
    public sealed class OnWalkEvent : UnityEvent
    {
    }

    [Serializable]
    public sealed class OnRunEvent : UnityEvent
    {
    }

    [Serializable]
    public sealed class OnMoveEvent : UnityEvent
    {
    }
}
