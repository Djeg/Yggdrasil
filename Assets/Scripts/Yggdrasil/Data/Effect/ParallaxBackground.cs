using System;
using UnityEngine;

namespace Yggdrasil.Data.Effect
{
    /**
     * <summary>
     * Contains all the data needed to create a parallax background.
     * </summary>
     */
    [Serializable]
    public struct ParallaxBackground
    {
        # region Properties

        /**
         * <summary>
         * Define the parallax scrolling speed
         * </summary>
         */
        public Vector2 scrollingIntensity;

        /**
         * <summary>
         * Define the movement speed 
         * </summary>
         */
        public Vector2 movementIntensity;

        /**
         * <summary>
         * Does this parallax must be repeated on the Y axis
         * </summary>
         */
        public bool repeatY;

        /**
         * <summary>
         * The camera to follow
         * </summary>
         */
        public Camera mainCamera;

        /**
         * <summary>
         * The last camera position
         * </summary>
         */
        [HideInInspector]
        public Vector3 lastCameraPosition;

        /**
         * <summary>
         * The camera transform
         * </summary>
         */
        [HideInInspector]
        public Transform cameraTransform; 

        /**
         * <summary>
         * The texture unit size
         * </summary>
         */
        [HideInInspector]
        public float textureUnitSizeX;

        /**
         * <summary>
         * The texture unit size
         * </summary>
         */
        [HideInInspector]
        public float textureUnitSizeY;

        # endregion

        # region PropertyAccessors
        # endregion

        # region PublicMethods
        # endregion
    }
}
