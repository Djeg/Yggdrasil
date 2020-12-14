using UnityEngine;

namespace Djeg.Yggdrasil.Background.Component
{
    /**
     * <summary>
     * Control parallax background
     * </summary>
     */
    [RequireComponent(typeof(SpriteRenderer))]
    public class ControlParallaxBackground : MonoBehaviour
    {
        # region Properties

        /**
         * <summary>
         * Define the parallax scrolling speed
         * </summary>
         */
        [SerializeField]
        [Tooltip("Define the speed of the scroll effect. 1 means that the background will never scroll and 0 means it scrolls at the same speed has the camera.")]
        private Vector2 _scrollingIntensity = Vector2.zero;

        /**
         * <summary>
         * Define the movement speed 
         * </summary>
         */
        [SerializeField]
        [Tooltip("Add the ability of a background to scroll automatically without a camera movement.")]
        private Vector2 _movementIntensity = Vector2.zero;

        /**
         * <summary>
         * Does this parallax must be repeated on the x axis
         * </summary>
         */
        [SerializeField]
        [Tooltip("Make this background repeat on the X axis")]
        private bool _repeatX = true;

        /**
         * <summary>
         * Does this parallax must be repeated on the Y axis
         * </summary>
         */
        [SerializeField]
        [Tooltip("Make this background repeat on the Y axis")]
        private bool _repeatY = false;

        /**
         * <summary>
         * The camera to follow
         * </summary>
         */
        [SerializeField]
        [Tooltip("The camera that the background has to follow")]
        private Camera _mainCamera = null;

        /**
         * <summary>
         * The last camera position
         * </summary>
         */
        private Vector3 _lastCameraPosition = Vector3.zero;

        /**
         * <summary>
         * The camera transform
         * </summary>
         */
        private Transform _cameraTransform = null; 

        /**
         * <summary>
         * A reference to the game object tranform
         * </summary>
         */
        private Transform _transform = null;

        /**
         * <summary>
         * The texture unit size
         * </summary>
         */
        private float _textureUnitSizeX = 0f;

        /**
         * <summary>
         * The texture unit size
         * </summary>
         */
        private float _textureUnitSizeY = 0f;

        # endregion

        # region PropertyAccessors

        /**
         * <summary>
         * Get and set the scrolling intensity
         * </summary>
         */
        public Vector2 ScrollingIntensity
        {
            get => _scrollingIntensity;
            set => _scrollingIntensity = value;
        }

        /**
         * <summary>
         * Get and set the movement intensity
         * </summary>
         */
        public Vector2 MovementIntensity
        {
            get => _movementIntensity;
            set => _movementIntensity = value;
        }

        /**
         * <summary>
         * Get and set the repeat X
         * </summary>
         */
        public bool RepeatX
        {
            get => _repeatX;
            set => _repeatX = value;
        }

        /**
         * <summary>
         * Get and set the repeat Y
         * </summary>
         */
        public bool RepeatY
        {
            get => _repeatY;
            set => _repeatY = value;
        }

        /**
         * <summary>
         * Retrieve the main camera
         * </summary>
         */
        public Camera MainCamera { get => _mainCamera; }

        /**
         * <summary>
         * Retrieve the texture unit size as a Vector2
         * </summary>
         */
        public Vector2 TextureUnitSize
        {
            get => new Vector2(_textureUnitSizeX, _textureUnitSizeY);
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
            _transform              = gameObject.transform;
            _cameraTransform        = _mainCamera.transform;
            _lastCameraPosition     = _cameraTransform.position;
            SpriteRenderer renderer = GetComponent<SpriteRenderer>();
            _textureUnitSizeX       = renderer.sprite.texture.width / renderer.sprite.pixelsPerUnit;
            _textureUnitSizeY       = renderer.sprite.texture.height / renderer.sprite.pixelsPerUnit;
        }

        /**
         * <inheritdoc/>
         */
        private void FixedUpdate()
        {
            Vector3 deltaMovement = _cameraTransform.position - _lastCameraPosition;
            Vector3 betaMovement  = deltaMovement + new Vector3(
                _movementIntensity.x / 100,
                _movementIntensity.y / 100,
                _transform.position.z
            );
            Vector3 finalMovement = new Vector3(
                betaMovement.x * _scrollingIntensity.x,
                betaMovement.y * _scrollingIntensity.y,
                _transform.position.z
            );

            _transform.position = new Vector3(
                _transform.position.x + finalMovement.x,
                _transform.position.y + finalMovement.y,
                _transform.position.z
            );
            _lastCameraPosition = _cameraTransform.position;

            if (_repeatX && Mathf.Abs(_cameraTransform.position.x - _transform.position.x) >= _textureUnitSizeX)
            {
                float offsetPositionX = (_cameraTransform.position.x - _transform.position.x) % _textureUnitSizeX;
                _transform.position = new Vector3(
                    _cameraTransform.position.x + offsetPositionX,
                    _transform.position.y,
                    _transform.position.z
                );
            }

            if (_repeatY && Mathf.Abs(_cameraTransform.position.y - _transform.position.y) >= _textureUnitSizeY)
            {
                float offsetPositionY = (_cameraTransform.position.y - _transform.position.y) % _textureUnitSizeY;
                _transform.position = new Vector3(
                    _transform.position.x,
                    _cameraTransform.position.y + offsetPositionY,
                    _transform.position.z
                );
            }
        }

        # endregion
    }
}
