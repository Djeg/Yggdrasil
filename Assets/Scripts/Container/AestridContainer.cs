using UnityEngine;
using Core;
using Data;
using Behaviour;

namespace Container
{
    /**
     * <summary>
     * Contains all the data that the aestrid game object need in order
     * to work properly.
     * </summary>
     */
    public class AestridContainer : MonoDataContainer
    {
        # region Properties

        /**
         * <summary>
         * Control the movement
         * </summary>
         */
        [SerializeField]
        private MovementData _movement;

        /**
         * <summary>
         * Control the hit boxes
         * </summary>
         */
        [SerializeField]
        private AttackCollectionData _attacks;

        /**
         * <summary>
         * Contains the character statistics
         * </summary>
         */
        [SerializeField]
        private CharacterStatData _stat;

        # endregion

        # region PropertyAccessors
        # endregion

        # region PublicMethods
        # endregion

        # region PrivateMethods
        # endregion
    }
}
