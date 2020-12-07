using System.Collections;
using UnityEngine;
using Yggdrasil.Core;
using Yggdrasil.Data.Effect;

namespace Yggdrasil.Controller.Effect
{
    /**
     * <summary>
     * Control parallax background
     * </summary>
     */
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireData(typeof(ParallaxBackground))]
    public class ControlParallaxBackground : MonoDataController
    {
        # region Properties

        /**
         * <summary>
         * A reference to the parallox data
         * </summary>
         */
        private ParallaxBackground _data;

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
            _data                    = GetData<ParallaxBackground>();
            _transform               = gameObject.transform;
            _data.cameraTransform    = _data.mainCamera.transform;
            _data.lastCameraPosition = _data.cameraTransform.position;
            SpriteRenderer renderer  = GetComponent<SpriteRenderer>();
            _data.textureUnitSizeX   = renderer.sprite.texture.width / renderer.sprite.pixelsPerUnit;
            _data.textureUnitSizeY   = renderer.sprite.texture.height / renderer.sprite.pixelsPerUnit;
        }

        /**
         * <inheritdoc/>
         */
        private void FixedUpdate()
        {
            Vector3 deltaMovement = _data.cameraTransform.position - _data.lastCameraPosition;
            Vector3 betaMovement  = deltaMovement + new Vector3(
                _data.movementIntensity.x / 100,
                _data.movementIntensity.y / 100,
                _transform.position.z
            );
            Vector3 finalMovement = new Vector3(
                betaMovement.x * _data.scrollingIntensity.x,
                betaMovement.y * _data.scrollingIntensity.y,
                _transform.position.z
            );

            _transform.position += finalMovement;
            _data.lastCameraPosition = _data.cameraTransform.position;

            if (Mathf.Abs(_data.cameraTransform.position.x - _transform.position.x) >= _data.textureUnitSizeX)
            {
                float offsetPositionX = (_data.cameraTransform.position.x - _transform.position.x) % _data.textureUnitSizeX;
                _transform.position = new Vector3(
                    _data.cameraTransform.position.x + offsetPositionX,
                    _transform.position.y,
                    _transform.position.z
                );
            }

            if (_data.repeatY && Mathf.Abs(_data.cameraTransform.position.y - _transform.position.y) >= _data.textureUnitSizeY)
            {
                float offsetPositionY = (_data.cameraTransform.position.y - _transform.position.y) % _data.textureUnitSizeY;
                _transform.position = new Vector3(
                    _transform.position.x,
                    _data.cameraTransform.position.y + offsetPositionY,
                    _transform.position.z
                );
            }

            // Finaly we set the data in order to update the struct
            SetData(_data);
        }

        # endregion
    }
}
