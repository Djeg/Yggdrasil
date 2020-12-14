using System.Collections;
using UnityEngine;

namespace Djeg.Yggdrasil.Movement.Data
{
    /**
     * <summary>
     * This is the data of an attack movement.
     * </summary>
     */
    [System.Serializable]
    public class Attack
    {
        # region Properties

        /**
         * <summary>
         * The hit box coordinates
         * </summary>
         */
        [Tooltip("The hit box position")]
        [Header("Hit Box")]
        public Vector2 position = Vector2.zero;

        /**
         * <summary>
         * The hit box radius
         * </summary>
         */
        public float radius = 0f;

        /**
         * <summary>
         * The pulse force given when this attack is triggered
         * </summary>
         */
        [Header("Force")]
        public Vector2 impulse = Vector2.zero;

        /**
         * <summary>
         * The force given to the victim
         * </summary>
         */
        public Vector2 force = Vector2.zero;

        /**
         * <summary>
         * Does this attack needs to be debug via gizsmos
         * </summary>
         */
        [Header("Debug")]
        public bool debug = false;

        /**
         * <summary>
         * The color of the debug circle
         * </summary>
         */
        public Color debugColor = Color.red;

        # endregion

        # region PropertyAccessors
        # endregion

        # region PublicMethods
        # endregion

        # region PrivateMethods
        # endregion
    }
}
