using System;
using UnityEngine;

namespace Data
{
    /**
     * <summary>
     * Contains all the data needed in order to make a parallax effect.
     * </summary>
     */
    [Serializable]
    public class ParallaxBackgroundData
    {
        # region Properties

        /**
         * <summary>
         * Define the parallax scrolling speed
         * </summary>
         */
        [Tooltip("Define the speed of the scroll effect. 1 means that the background will never scroll and 0 means it scrolls at the same speed has the camera.")]
        public Vector2 scrollingIntensity = Vector2.zero;

        /**
         * <summary>
         * Define the movement speed 
         * </summary>
         */
        [Tooltip("Add the ability of a background to scroll automatically without a camera movement.")]
        public Vector2 movementIntensity = Vector2.zero;

        /**
         * <summary>
         * Does this parallax must be repeated on the x axis
         * </summary>
         */
        [Tooltip("Make this background repeat on the X axis")]
        public bool repeatX = true;

        /**
         * <summary>
         * Does this parallax must be repeated on the Y axis
         * </summary>
         */
        [Tooltip("Make this background repeat on the Y axis")]
        public bool repeatY = false;

        /**
         * <summary>
         * The camera to follow
         * </summary>
         */
        [Tooltip("The camera that the background has to follow")]
        public Camera mainCamera = null;

        /**
         * <summary>
         * The last camera position
         * </summary>
         */
        [HideInInspector]
        public Vector3 lastCameraPosition = Vector3.zero;

        /**
         * <summary>
         * The camera transform
         * </summary>
         */
        [HideInInspector]
        public Transform cameraTransform = null; 

        /**
         * <summary>
         * The texture unit size
         * </summary>
         */
        [HideInInspector]
        public float textureUnitSizeX = 0f;

        /**
         * <summary>
         * The texture unit size
         * </summary>
         */
        [HideInInspector]
        public float textureUnitSizeY = 0f;

        # endregion

        # region PropertyAccessors
        # endregion
    }
}
