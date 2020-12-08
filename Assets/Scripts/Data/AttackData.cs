using System;
using UnityEngine;
using Event;

namespace Data
{
    /**
     * <summary>
     * Contains the data of a hit box. In order to trigger a hit you just
     * have to use AttackData.requestHit attribute. If you want to be notified
     * when the hit box has touch something, use the onHit event.
     * </summary>
     */
    [Serializable]
    public class AttackData
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
         * Does this attack freeze the movement
         * </summary>
         */
        [Tooltip("Freeze the character movement during the attack if checked.")]
        public bool isFrozenMovement = true;

        /**
         * <summary>
         * Can this attack be interupted
         * </summary>
         */
        [Tooltip("If true, the attack can be interupted by a hurt or other animations.")]
        public bool canBeInterupted = false;

        /**
         * <summary>
         * Add a pulse force to trigger
         * </summary>
         */
        [Tooltip("The is a force to impulse when the attack is triggered")]
        public Vector2 pulseForce = Vector2.zero;

        /**
         * <summary>
         * Auto trigger the pulse force
         * </summary>
         */
        [Tooltip("If true the pulse force is apply when the attack start. If false, it must be apply manualy")]
        public bool automaticPulse = true;

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
