using System.Collections;
using UnityEngine;
using Djeg.Yggdrasil.Persona.Behaviour;
using Djeg.Yggdrasil.Persona.Data;

namespace Djeg.Yggdrasil.Persona.Variable
{
    /**
     * <summary>
     * Contains the persona health and armor as a scriptable object
     * </summary>
     */
    public class HeroPersonaData : ScriptableObject, IPersonaHealth, IPersonaArmor
    {
        # region Properties

        /**
         * <summary>
         * The max health
         * </summary>
         */
        [SerializeField]
        private int _maxHealth = 100;

        /**
         * <summary>
         * The max armor
         * </summary>
         */
        [SerializeField]
        private int _maxArmor = 100;

        /**
         * <summary>
         * The current health
         * </summary>
         */
        [SerializeField]
        private int _currentHealth = 100;

        /**
         * <summary>
         * The current armor
         * </summary>
         */
        [SerializeField]
        private int _currentArmor = 100;

        # endregion

        # region PropertyAccessors

        /**
         * <summary>
         * Get the max health
         * </summary>
         */
        public int MaxHealth { get => _maxHealth; }

        /**
         * <summary>
         * Get the max armor
         * </summary>
         */
        public int MaxArmor { get => _maxArmor; }

        /**
         * <summary>
         * The current health
         * </summary>
         */
        public int CurrentHealth { get => _currentHealth; }

        /**
         * <summary>
         * The current armro
         * </summary>
         */
        public int CurrentArmor { get => _currentArmor; }

        # endregion

        # region PublicMethods

        /**
         * <inheritdoc/>
         */
        public void RestoreHealth(int amount = 0)
        {
            _currentHealth += amount;

            if (_currentHealth > _maxHealth)
                _currentHealth = _maxHealth;
        }

        /**
         * <inheritdoc/>
         */
        public void RestoreArmor(int amount = 0)
        {
            _currentArmor += amount;

            if (_currentArmor > _maxArmor)
                _currentArmor = _maxArmor;
        }

        /**
         * <inheritdoc/>
         */
        public void DamageHealth(PersonaDamage damage)
        {
            _currentHealth -= damage.amount;

            if (_currentHealth < 0)
                _currentHealth = 0;
        }

        /**
         * <inheritdoc/>
         */
        public void DamageArmor(PersonaDamage damage)
        {
            _currentArmor -= damage.amount;

            if (_currentArmor < 0)
                _currentArmor = 0;
        }

        /**
         * <inheritdoc/>
         */
        public void UpgradeHealth(int amount = 0) => _maxHealth += amount;

        /**
         * <inheritdoc/>
         */
        public void UpgradeArmor(int amount = 0) => _maxArmor += amount;

        # endregion

        # region PrivateMethods
        # endregion
    }
}
