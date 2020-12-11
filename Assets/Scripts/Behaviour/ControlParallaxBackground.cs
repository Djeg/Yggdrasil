using System;
using UnityEngine;
using Core;
using Data;

namespace Behaviour
{
    /**
     * <summary>
     * Handle parallax background
     * </summary>
     */
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireData(typeof(ParallaxBackgroundData))]
    public class ControlParallaxBackground : MonoDataBehaviour
    {
        # region Properties

        /**
         * <summary>
         * A reference to the parallow data
         * </summary>
         */
        private ParallaxBackgroundData _parallax;

        /**
         * <summary>
         * A reference to the current object transform
         * </summary>
         */
        private Transform _transform = null;

        # endregion

        # region PropertyAccessors
        # endregion

        # region PublicMethods
        # endregion

        # region PrivateMethods

        /**
         * <inheritdoc/>
         */
        protected override void Init(MonoDataContainer container)
        {
            _parallax                    = GetData<ParallaxBackgroundData>();
            _transform                   = gameObject.transform;
            _parallax.cameraTransform    = _parallax.mainCamera.transform;
            _parallax.lastCameraPosition = _parallax.cameraTransform.position;
            SpriteRenderer renderer      = GetComponent<SpriteRenderer>();
            _parallax.textureUnitSizeX   = renderer.sprite.texture.width / renderer.sprite.pixelsPerUnit;
            _parallax.textureUnitSizeY   = renderer.sprite.texture.height / renderer.sprite.pixelsPerUnit;
        }

        /**
         * <inheritdoc/>
         */
        private void FixedUpdate()
        {
            Vector3 deltaMovement = _parallax.cameraTransform.position - _parallax.lastCameraPosition;
            Vector3 betaMovement  = deltaMovement + new Vector3(
                _parallax.movementIntensity.x / 100,
                _parallax.movementIntensity.y / 100,
                _transform.position.z
            );
            Vector3 finalMovement = new Vector3(
                betaMovement.x * _parallax.scrollingIntensity.x,
                betaMovement.y * _parallax.scrollingIntensity.y,
                _transform.position.z
            );

            _transform.position = new Vector3(
                _transform.position.x + finalMovement.x,
                _transform.position.y + finalMovement.y,
                _transform.position.z
            );
            _parallax.lastCameraPosition = _parallax.cameraTransform.position;

            if (_parallax.repeatX && Mathf.Abs(_parallax.cameraTransform.position.x - _transform.position.x) >= _parallax.textureUnitSizeX)
            {
                float offsetPositionX = (_parallax.cameraTransform.position.x - _transform.position.x) % _parallax.textureUnitSizeX;
                _transform.position = new Vector3(
                    _parallax.cameraTransform.position.x + offsetPositionX,
                    _transform.position.y,
                    _transform.position.z
                );
            }

            if (_parallax.repeatY && Mathf.Abs(_parallax.cameraTransform.position.y - _transform.position.y) >= _parallax.textureUnitSizeY)
            {
                float offsetPositionY = (_parallax.cameraTransform.position.y - _transform.position.y) % _parallax.textureUnitSizeY;
                _transform.position = new Vector3(
                    _transform.position.x,
                    _parallax.cameraTransform.position.y + offsetPositionY,
                    _transform.position.z
                );
            }
        }

        # endregion
    }
}
