using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using Djeg.Yggdrasil.Movement.Data;

namespace Djeg.Yggdrasil.Movement.Component
{
    /**
     * <summary>
     * Control the ability of an object to drag on surfaces when falling
     * of a jump.
     * </summary>
     */
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(ControlJumpMovement))]
    [RequireComponent(typeof(ControlHorizontalMovement))]
    public class ControlDraggingJumpMovement : MonoBehaviour
    {
        # region Properties

        /**
         * <summary>
         * The intensity of the drag
         * </summary>
         */
        [SerializeField]
        [Header("Parameters")]
        [Range(1f, 100f)]
        private float _intensity = 20f;

        /**
         * <summary>
         * The force of the push back
         * </summary>
         */
        [SerializeField]
        [Range(1f, 100f)]
        private float _pushForce = 15f;

        /**
         * <summary>
         * Define the time of the drag jump
         * </summary>
         */
        [SerializeField]
        [Range(0f, 1f)]
        private float _draggedJumpTime = 0.25f;

        /**
         * <summary>
         * The raycast length
         * </summary>
         */
        [SerializeField]
        [Range(0.1f, 5f)]
        private float _raycastLength = 0.5f;

        /**
         * <summary>
         * The raycast offset Y
         * </summary>
         */
        [SerializeField]
        [Range(-5f, 5f)]
        private float _raycastOffsetY = 0f;


        /**
         * <summary>
         * The raycast offset X
         * </summary>
         */
        [SerializeField]
        [Range(-5f, 5f)]
        private float _raycastOffsetX = 0f;

        /**
         * <summary>
         * The raycast debug color
         * </summary>
         */
        [SerializeField]
        private Color _debugColor = Color.blue;

        /**
         * <summary>
         * The OnDragStartEvent
         * </summary>
         */
        [SerializeField]
        [Header("Events")]
        private OnDragStartEvent _onDragStart = new OnDragStartEvent();

        /**
         * <summary>
         * The OnDragEndEvent
         * </summary>
         */
        [SerializeField]
        private OnDragEndEvent _onDragEnd = new OnDragEndEvent();

        /**
         * <summary>
         * The OnDragJumpEvent
         * </summary>
         */
        [SerializeField]
        private OnDragJumpEvent _onDragJump = new OnDragJumpEvent();

        /**
         * <summary>
         * This boolean allows to fix the bug that decrease the push force
         * when attacking
         * </summary>
         */
        private bool _hasAttack = false;

        /**
         * <summary>
         * Determine of the object is currenlty dragging
         * </summary>
         */
        private bool _dragging = false;

        /**
         * <summary>
         * Determine if the object is colliding with a wall
         * </summary>
         */
        private bool _colliding = false;

        /**
         * <summary>
         * A reference to the Rigidbody2D
         * </summary>
         */
        private Rigidbody2D _body = null;

        /**
         * <summary>
         * A reference to the ControlJumpMovement
         * </summary>
         */
        private ControlJumpMovement _jump = null;

        /**
         * <summary>
         * A reference to the ControlHorizontalMovement
         * </summary>
         */
        private ControlHorizontalMovement _movement = null;

        /**
         * <summary>
         * A reference to the ControlHorizontalMovement
         * </summary>
         */
        private HorizontalDirection _currentDirection = HorizontalDirection.Right;

        # endregion

        # region PropertyAccessors

        /**
         * <summary>
         * get and set the intensity
         * </summary>
         */
        public float Intensity
        {
            get => _intensity;
            set => _intensity = value;
        }

        /**
         * <summary>
         * get and set the push force
         * </summary>
         */
        public float PushForce
        {
            get => _pushForce;
            set => _pushForce = value;
        }

        /**
         * <summary>
         * Retrieve teh dragging state
         * </summary>
         */
        public bool Dragging { get => _dragging; }

        /**
         * <summary>
         * Retrieve the colliding state
         * </summary>
         */
        public bool Colliding { get => _colliding; }

        /**
         * <summary>
         * Retrieve the OnDragStartEvent
         * </summary>
         */
        public OnDragStartEvent OnDragStart { get => _onDragStart; }

        /**
         * <summary>
         * Retrieve the OnDragEndEvent
         * </summary>
         */
        public OnDragEndEvent OnDragEnd { get => _onDragEnd; }

        /**
         * <summary>
         * Retrieve the OnDragJumpEvent
         * </summary>
         */
        public OnDragJumpEvent OnDragJump { get => _onDragJump; }

        # endregion

        # region PublicMethods
        # endregion

        # region PrivateMethods

        /**
         * <inheritdoc/>
         */
        private void Awake()
        {
            _body             = GetComponent<Rigidbody2D>();
            _jump             = GetComponent<ControlJumpMovement>();
            _movement         = GetComponent<ControlHorizontalMovement>();
            _currentDirection = _movement.Direction;
        }

        /**
         * <inheritdoc/>
         */
        private void OnEnable()
        {
            _jump.OnRise.AddListener(OnJump);
            _movement.OnDirectionChanged.AddListener(OnDirectionChanged);

            ControlAttackMovement attack = GetComponent<ControlAttackMovement>();

            if (null == attack)
                return;

            attack.OnAttackStart.AddListener(HandleAttackBug);
        }

        /**
         * <inheritdoc/>
         */
        private void OnDisable()
        {
            _jump.OnRise.RemoveListener(OnJump);
            _movement.OnDirectionChanged.RemoveListener(OnDirectionChanged);

            ControlAttackMovement attack = GetComponent<ControlAttackMovement>();

            if (null == attack)
                return;

            attack.OnAttackStart.RemoveListener(HandleAttackBug);
        }

        /**
         * <summary>
         * Handle the decrease of the push force bug when attacking
         * </summary>
         */
        private void HandleAttackBug()
        {
            if (_hasAttack)
                return;

            _hasAttack = true;
            _pushForce += 5;
        }

        /**
         * <inheritdoc/>
         */
        private void FixedUpdate()
        {
            bool colliding         = IsColliding();
            bool dragging          = IsDragging();
            bool invokeOnDragStart = dragging && !_dragging;
            bool invokeOnDragEnd   = !dragging && _dragging;

            _colliding          = colliding;
            _dragging           = dragging;
            _body.drag          = dragging ? _intensity : 0f;
            _jump.AllowNextJump = dragging;

            if (invokeOnDragStart)
                OnDragStart.Invoke();

            if (invokeOnDragEnd)
                OnDragEnd.Invoke();
        }

        /**
         * <summary>
         * Add a force to the body when jumping
         * </summary>
         */
        private void OnJump()
        {
            if (!_dragging)
                return;

            _movement.FlipDirection();
            _movement.enabled = false;

            Vector2 force = HorizontalDirectionHelper.ToVector2(_currentDirection);

            _body.AddForce(
                force * _pushForce,
                ForceMode2D.Impulse
            );

            OnDragJump.Invoke();

            // TODO encapsulate this logic inside an animation
            StartCoroutine(EnableMovementAfterJump());
        }

        /**
         * <summary>
         * Enable the _movement component after an amount of time
         * </summary>
         */
        private IEnumerator EnableMovementAfterJump()
        {
            yield return new WaitForSeconds(_draggedJumpTime);

            _movement.enabled = true;
        }

        /**
         * <summary>
         * When the direction change update the direction of this dragging
         * </summary>
         */
        private void OnDirectionChanged(HorizontalDirection oldDirection, HorizontalDirection direction)
        {
            _currentDirection = direction;
            _raycastOffsetX   = -_raycastOffsetX;
        }

        /**
         * <summary>
         * Test if the object is colliding
         * </summary>
         */
        private bool IsColliding()
        {
            Vector2 position = new Vector2(
                transform.position.x + _raycastOffsetX,
                transform.position.y + _raycastOffsetY
            );

            RaycastHit2D hit = Physics2D.Raycast(
                position,
                HorizontalDirectionHelper.ToVector2(_currentDirection),
                _raycastLength,
                _jump.Layer
            );

            return null != hit.collider;
        }

        /**
         * <summary>
         * Test if the object is dragging
         * </summary>
         */
        private bool IsDragging() => _jump.Falling && _colliding;

        /**
         * <inheritdoc/>
         */
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = _debugColor;
            float xPosition = transform.position.x + _raycastOffsetX;
            float yPosition = transform.position.y + _raycastOffsetY;
            float xTarget = HorizontalDirectionHelper.Parse(_currentDirection, _raycastLength);

            Vector3 target = new Vector3(
                xPosition + xTarget,
                yPosition,
                transform.position.z
            );

            Vector3 center = new Vector3(
                xPosition,
                yPosition,
                transform.position.z
            );

            Gizmos.DrawLine(center, target);
        }

        # endregion
    }

    [System.Serializable]
    public sealed class OnDragStartEvent : UnityEvent
    {
    }

    [System.Serializable]
    public sealed class OnDragEndEvent : UnityEvent
    {
    }

    [System.Serializable]
    public sealed class OnDragJumpEvent : UnityEvent
    {
    }
}
