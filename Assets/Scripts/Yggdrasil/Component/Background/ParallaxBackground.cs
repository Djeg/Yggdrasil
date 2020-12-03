using System.Collections;
using UnityEngine;

namespace Yggdrasil.Component.Background
{
    /**
     * <summary>
     * Make a parallax background based on camera.
     * </summary>
     */
    [RequireComponent(typeof(SpriteRenderer))]
    public class ParallaxBackground : MonoBehaviour
    {
        # region Properties

        /**
         * <summary>
         * Define the parallax speed
         * </summary>
         */
        [SerializeField]
        private Vector2 speed = Vector3.zero;

        /**
         * <summary>
         * Define the movement speed 
         * </summary>
         */
        [SerializeField]
        private Vector2 movement = Vector3.zero;

        /**
         * <summary>
         * Does this parallax must be repeated on the Y axis
         * </summary>
         */
        [SerializeField]
        private bool repeatY = false;

        /**
         * <summary>
         * The last camera position
         * </summary>
         */
        private Vector3 lastCameraPosition = Vector3.zero;

        /**
         * <summary>
         * The camera transform
         * </summary>
         */
        private Transform cameraTransform = null;

        /**
         * <summary>
         * The texture unit size
         * </summary>
         */
        private float textureUnitSizeX = 0;

        /**
         * <summary>
         * The texture unit size
         * </summary>
         */
        private float textureUnitSizeY = 0;

        # endregion

        # region PropertyAccessors
        # endregion

        # region PublicMethods
        # endregion

        # region PrivateMethods

        /**
         * <summary>
         * On each late update
         * </summary>
         */
        private void FixedUpdate()
        {
            Vector3 deltaMovement = (cameraTransform.position - lastCameraPosition);
            Vector3 betaMovement = deltaMovement + new Vector3(movement.x / 100, movement.y / 100);
            Vector3 finalMovement = new Vector3(
                betaMovement.x * speed.x * Time.fixedDeltaTime,
                betaMovement.y * speed.y * Time.fixedDeltaTime
            );

            transform.position += finalMovement;

            lastCameraPosition = cameraTransform.position;

            if (Mathf.Abs(cameraTransform.position.x - transform.position.x) >= textureUnitSizeX) {
                float offsetPositionX = (cameraTransform.position.x - transform.position.x) % textureUnitSizeX;
                transform.position = new Vector3(
                    cameraTransform.position.x + offsetPositionX,
                    cameraTransform.position.y
                );
            }

            if (repeatY && Mathf.Abs(cameraTransform.position.y - transform.position.y) >= textureUnitSizeY) {
                float offsetPositionY = (cameraTransform.position.y - transform.position.y) % textureUnitSizeY;
                transform.position = new Vector3(
                    cameraTransform.position.y,
                    cameraTransform.position.y + offsetPositionY
                );
            }
        }

        /**
         * <summary>
         * When awake
         * </summary>
         */
        private void Awake()
        {
            cameraTransform = Camera.main.transform;
            lastCameraPosition = cameraTransform.position;

            SpriteRenderer renderer = GetComponent<SpriteRenderer>();
            textureUnitSizeX = renderer.sprite.texture.width / renderer.sprite.pixelsPerUnit;
            textureUnitSizeY = renderer.sprite.texture.height / renderer.sprite.pixelsPerUnit;
        }

        # endregion
    }
}
