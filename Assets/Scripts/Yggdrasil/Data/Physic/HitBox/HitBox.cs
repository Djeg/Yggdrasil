using System;
using UnityEngine;

namespace Yggdrasil.Data.Physic.HitBox
{
    /**
     * <summary>
     * Contains the data of a hit box. In order to trigger a hit you just
     * have to use HitBox.requestHit attribute. If you want to be notified
     * when the hit box has touch something, use the onHit event.
     * </summary>
     */
    [Serializable]
    public class HitBox
    {
        # region Properties

        /**
         * <summary>
         * The hit box x offset
         * </summary>
         */
        [Tooltip("The x offset position of the hit box")]
        [Range(-2f, 2f)]
        public float offsetX = 0f;

        /**
         * <summary>
         * The hit box y offset
         * </summary>
         */
        [Tooltip("The y offset position of the hit box")]
        [Range(-2f, 2f)]
        public float offsetY = 0f;

        /**
         * <summary>
         * The hit boc circle radius
         * </summary>
         */
        [Tooltip("The hit box radius")]
        [Range(0f, 2f)]
        public float radius = .5f;

        /**
         * <summary>
         * Draw or not this hit box on screen
         * </summary>
         */
        [Tooltip("Display the hit box using gizmos")]
        public bool debug = false;

        /**
         * <summary>
         * The color attached to the debug circle
         * </summary>
         */
        [Tooltip("Define the color of the displayed hit box")]
        public Color color = Color.red;

        /**
         * <summary>
         * Attach some event on this hit box. Used in order to get notified
         * when this hit box has hit something.
         * </summary>
         */
        [Tooltip("Event triggered when this hit box is hitting other MonoController")]
        public HitEvent onHit;

        /**
         * <summary>
         * Ask for this hit box to request a hit
         * </summary>
         */
        [HideInInspector]
        public bool requestHit = false;

        # endregion

        # region PropertyAccessors
        # endregion
    }
}
