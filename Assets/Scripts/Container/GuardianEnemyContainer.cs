using UnityEngine;
using Core;
using Data;

namespace Container
{
    /**
     * <summary>
     * Contains all the data needed to make a Draugr enemy
     * </summary>
     */
    public class GuardianEnemyContainer : MonoDataContainer
    {
        # region Properties

        /**
         * <summary>
         * The movement data
         * </summary>
         */
        [SerializeField]
        private MovementData _movement;

        /**
         * <summary>
         * The attack collection data
         * </summary>
         */
        [SerializeField]
        private AttackCollectionData _attacks;

        /**
         * <summary>
         * The guardian data
         * </summary>
         */
        [SerializeField]
        private GuardianData _guardian;

        /**
         * <summary>
         * Contains the character data
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
