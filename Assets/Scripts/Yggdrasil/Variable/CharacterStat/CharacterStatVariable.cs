using System;
using UnityEngine;

namespace Yggdrasil.Variable.CharacterStat
{
    /**
     * <summary>
     * Contains the character base data such as health, armor and attack.
     * </summary>
     */
    [Serializable]
    [CreateAssetMenu(fileName="CharacterStat", menuName="Variables/CharacterStat")]
    public class CharacterStatVariable : ScriptableObject
    {
        # region Properties

        /**
         * <summary>
         * The maximum health of a character.
         * </summary>
         */
        public int maxHealth = 20;

        /**
         * <summary>
         * The current health of a character.
         * </summary>
         */
        public int currentHealth = 20;

        /**
         * <summary>
         * The armor max value of a character.
         * </summary>
         */
        public int maxArmor = 10;

        /**
         * <summary>
         * The armor current value of a character.
         * </summary>
         */
        public int currentArmor = 10;

        /**
         * <summary>
         * Determine the base attack. This is added to any damage dice.
         * </summary>
         */
        public int baseAttack = 0;

        # endregion

        # region PropertyAccessors
        # endregion
    }
}
