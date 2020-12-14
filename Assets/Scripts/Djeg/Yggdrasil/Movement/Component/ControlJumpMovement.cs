using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Djeg.Yggdrasil.Movement.Component
{
    /**
     * <summary>
     * Control the ability of a character to jump
     * </summary>
     */
    [RequireComponent(typeof(Rigidbody2D))]
    public class ControlJumpMovement : MonoBehaviour
    {
        # region Properties

        /**
         * <summary>
         * The jump force
         * </summary>
         */
        [SerializeField]
        [Header("Parameters")]
        [Tooltip("Determine the intensity of the jump")]
        private float _force = 10f;

        /**
         * <summary>
         * The jump time
         * </summary>
         */
        [SerializeField]
        [Tooltip("Determine the amount of time this personna can jump")]
        [Range(0f, 1f)]
        private float _duration = 0.25f;

        /**
         * <summary>
         * Determine the length of the ground raycast
         * </summary>
         */
        [SerializeField]
        [Tooltip("Determine the length of the raycast used to detect the ground (blue color)")]
        [Range(0f, 5f)]
        private float _raycastLength = 1.5f;

        /**
         * <summary>
         * Determine the layer used to detect the ground
         * </summary>
         */
        [SerializeField]
        [Tooltip("Define the layer used for ground collision.")]
        private LayerMask _layer = Physics2D.AllLayers;

        /**
         * <summary>
         * The color used for debuging the raycast
         * </summary>
         */
        [SerializeField]
        private Color _debugColor = Color.blue;

        /**
         * <summary>
         * Event triggered on rise
         * </summary>
         */
        [SerializeField]
        [Header("Events")]
        private OnRiseEvent _onRise = new OnRiseEvent();

        /**
         * <summary>
         * Event trigger on land
         * </summary>
         */
        [SerializeField]
        private OnLandEvent _onLand = new OnLandEvent();

        /**
         * <summary>
         * Event triggered when falling
         * </summary>
         */
        [SerializeField]
        private OnFallEvent _onFall = new OnFallEvent();

        /**
         * <summary>
         * Event trigger all the time during a jump
         * </summary>
         */
        [SerializeField]
        private OnJumpEvent _onJump = new OnJumpEvent();

        /**
         * <summary>
         * The previous Y position
         * </summary>
         */
        private float _previousY = 0f;

        /**
         * <summary>
         * Test if this object is jumping
         * </summary>
         */
        private bool _jumping = false;

        /**
         * <summary>
         * Overriden jumping boolean
         * </summary>
         */
        private bool _overrideJumping = false;

        /**
         * <summary>
         * Test if this object is falling
         * </summary>
         */
        private bool _falling = false;

        /**
         * <summary>
         * Determine if something from the outside is requesting
         * a jump
         * </summary>
         */
        private bool _requesting = false;

        /**
         * <summary>
         * Dermine if something from the outiside is holding the jump
         * </summary>
         */
        private bool _holding = false;

        /**
         * <summary>
         * The time counter
         * </summary>
         */
        private float _timeCounter = 0f;

        /**
         * <summary>
         * A reference to the Rigidbody2D
         * </summary>
         */
        private Rigidbody2D _body = null;

        # endregion

        # region PropertyAccessors

        /**
         * <summary>
         * Retrieve and set the force
         * </summary>
         */
        public float Force
        {
            get => _force;
            set => _force = value;
        }

        /**
         * <summary>
         * Retrieve and set the duration of a jump
         * </summary>
         */
        public float Duration
        {
            get => _duration;
            set => _duration = value;
        }

        /**
         * <summary>
         * Retrieve the jumping state
         * </summary>
         */
        public bool Jumping { get => _jumping; }

        /**
         * <summary>
         * Retrieve the falling state
         * </summary>
         */
        public bool Falling { get => _falling; }

        /**
         * <summary>
         * Retrieve the layer attached to this ControlJumpMovement
         * </summary>
         */
        public LayerMask Layer { get => _layer; }

        /**
         * <summary>
         * Allow next jump
         * </summary>
         */
        public bool AllowNextJump
        {
            get => _overrideJumping;
            set => _overrideJumping = value;
        }

        /**
         * <summary>
         * Retrieve the OnRiseEvent
         * </summary>
         */
        public OnRiseEvent OnRise { get => _onRise; }

        /**
         * <summary>
         * Retrieve the OnLandEvent
         * </summary>
         */
        public OnLandEvent OnLand { get => _onLand; }

        /**
         * <summary>
         * Retrieve the on fall event
         * </summary>
         */
        public OnFallEvent OnFall { get => _onFall; }

        /**
         * <summary>
         * Retrieve the OnJUmp
         * </summary>
         */
        public OnJumpEvent OnJump { get => _onJump; }

        # endregion

        # region PublicMethods

        /**
         * <summary>
         * Make a jump
         * </summary>
         */
        public void Jump()
        {
            if (!_jumping || _overrideJumping)
            {
                _requesting = true;
                _holding = true;
            }
        }

        /**
         * <summary>
         * Land an object
         * </summary>
         */
        public void ReleasePressure()
        {
            _holding = false;
        }

        # endregion

        # region PrivateMethods

        /**
         * <inheritdoc/>
         */
        private void Awake()
        {
            _body = GetComponent<Rigidbody2D>();
        }

        /**
         * <inheritdoc/>
         */
        private void OnEnable()
        {
            _previousY = transform.position.y;
        }

        /**
         * <inheritdoc/>
         */
        private void OnDisable()
        {
            _body.velocity = new Vector2(_body.velocity.x, 0);
        }

        /**
         * <inheritdoc/>
         */
        private void FixedUpdate()
        {
            bool jump = IsJumping();
            bool falling = IsFalling();
            bool invokeOnLand = !jump && _jumping;
            bool invokeOnFall = falling && !_falling;
            bool invokeOnRise = !_jumping && jump;

            _jumping = jump;
            _falling = falling;

            if (_requesting && (!_jumping || _overrideJumping))
            {
                ApplyJumpVelocity();

                _requesting      = false;
                _overrideJumping = false;
                _timeCounter     = _duration;
                invokeOnRise     = true;
            }

            if (!_requesting && _holding && _jumping && _timeCounter > 0)
            {
                ApplyJumpVelocity();

                _timeCounter -= Time.deltaTime;
            }

            if (jump)
                OnJump.Invoke();

            if (invokeOnLand)
                OnLand.Invoke();

            if (invokeOnFall)
                OnFall.Invoke();

            if (invokeOnRise)
                OnRise.Invoke();
        }

        /**
         * <summary>
         * Apply the jump velocity
         * </summary>
         */
        private void ApplyJumpVelocity() =>
            _body.velocity = new Vector2(
                _body.velocity.x,
                _force
            );

        /**
         * <summary>
         * When pressing down the jump input
         * </summary>
         */
        private void OnJumpPressedInput() => Jump();

        /**
         * <summary>
         * When releasing the jump input
         * </summary>
         */
        private void OnJumpReleasedInput() => ReleasePressure();

        /**
         * <inheritdoc/>
         */
        private void OnDrawGizmosSelected()
        {
            Gizmos.color   = _debugColor;
            Vector3 target = new Vector3(
                transform.position.x,
                transform.position.y - _raycastLength,
                transform.position.z
            );

            Gizmos.DrawLine(transform.position, target);
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
                _raycastLength,
                _layer
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

            return _jumping && fall;
        }

        # endregion
    }

    [System.Serializable]
    public sealed class OnLandEvent : UnityEvent
    {
    }

    [System.Serializable]
    public sealed class OnRiseEvent : UnityEvent
    {
    }

    [System.Serializable]
    public sealed class OnFallEvent : UnityEvent
    {
    }

    [System.Serializable]
    public sealed class OnJumpEvent : UnityEvent
    {
    }
}
