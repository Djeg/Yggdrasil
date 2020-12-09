using System;
using UnityEngine;
using Event;

namespace Data
{
    /**
     * <summary>
     * Allow a character to possess health, armor, strength and agility.
     * All those data are used in order to calculate the amount of damage
     * and resistance of a character.
     * </summary>
     */
    [Serializable]
    public class CharacterStatData
    {
        # region NestedTypes

        /**
         * <summary>
         * Contains the data of a damage
         * </summary>
         */
        public struct Damage
        {
            public int roll;
            public int amount;
            public bool isCritical;
        }

        # endregion

        # region Properties

        /**
         * <summary>
         * A reference of a Random instance
         * </summary>
         */
        private static System.Random _random = new System.Random();

        /**
         * <summary>
         * The character max health
         * </summary>
         */
        [Header("Parameters")]
        [Tooltip("The character max health")]
        [Range(0, 500)]
        public int maxHealth = 100;

        /**
         * <summary>
         * The character current health
         * </summary>
         */
        [Tooltip("The character current health")]
        [Range(0, 500)]
        public int health = 100;

        /**
         * <summary>
         * The character max damage value
         * </summary>
         */
        [Tooltip("Define the max amount of damage")]
        [Range(0, 50)]
        public int maxDamage = 12;

        /**
         * <summary>
         * The character critical range
         * </summary>
         */
        [Tooltip("Define the critical range. 1 means that a critical happens on each dice equals to maxDamage - 2")]
        [Range(0, 50)]
        public int criticalRange = 1;

        /**
         * <summary>
         * The critical modifier
         * </summary>
         */
        [Tooltip("Define the critical modifier. 2 means that a critical is equals to the damage * 2.")]
        [Range(0, 10)]
        public int criticalModifier = 2;

        /**
         * <summary>
         * Make the character invincible
         * </summary>
         */
        [Tooltip("Does this character is invincible")]
        public bool invincible = false;

        /**
         * <summary>
         * Event triggered when the character is taking damage.
         * </summary>
         */
        [Header("Events")]
        public CharacterDamageEvent onTakingDamage;

        /**
         * <summary>
         * Event triggered when the character is healing.
         * </summary>
         */
        public CharacterHealEvent onHeal;

        /**
         * <summary>
         * Event triggered when the character die
         * </summary>
         */
        public CharacterDieEvent onDie;

        # endregion

        # region PropertyAccessors

        /**
         * <summary>
         * Test if the character is still alive
         * </summary>
         */
        public bool IsDead { get => health <= 0; }

        # endregion

        # region PublicMethods

        /**
         * <summary>
         * Roll a dice based on the maxDamage amount.
         * </summary>
         */
        public Damage MakeDamage()
        {
            int amount = _random.Next(1, maxDamage + 1);
            bool isCritical = amount >= (maxDamage - criticalRange);

            return new Damage {
                roll = amount,
                amount = isCritical ? amount * criticalModifier : amount,
                isCritical = isCritical
            };
        }

        # endregion
    }
}
