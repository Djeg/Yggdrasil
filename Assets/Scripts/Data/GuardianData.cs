using System;
using UnityEngine;

namespace Data
{
    /**
     * <summary>
     * Contains all the data needed to make a guardian enemy.
     * </summary>
     */
    [Serializable]
    public class GuardianData
    {
        # region Properties

        /**
         * <summary>
         * vision length
         * </summary>
         */
        public float visionRange = 3f;

        /**
         * <summary>
         * The range of the left beacon
         * </summary>
         */
        public float leftBeaconRange = 3f;

        /**
         * <summary>
         * The range of the right beacon
         * </summary>
         */
        public float rightBeaconRange = 3f;

        /**
         * <summary>
         * The attack range
         * </summary>
         */
        public float attackRange = .5f;

        /**
         * <summary>
         * The running speed
         * </summary>
         */
        public float runningSpeed = 700f;

        /**
         * <summary>
         * Debug the guardian using gizmos
         * </summary>
         */
        public bool debug = false;

        /**
         * <summary>
         * Is it seing enemies
         * </summary>
         */
        public bool hasEnemiesInVision = false;

        /**
         * <summary>
         * Has enemies in range
         * </summary>
         */
        public bool hasEnemiesInAttackRange = false;

        # endregion

        # region PropertyAccessors
        # endregion
    }
}
