using System;
using UnityEngine;
using Djeg.Yggdrasil.Persona.Behaviour;

namespace Djeg.Yggdrasil.Persona.Data
{
    /**
     * <summary>
     * Implement a static persona health
     * </summary>
     */
    [Serializable]
    public class StaticPersonaHealth : IPersonaHealth
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
         * The current health
         * </summary>
         */
        [SerializeField]
        private int _currentHealth = 100;

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
         * Get the current health
         * </summary>
         */
        public int CurrentHealth { get => _currentHealth; }

        # endregion

        # region PublicMethods

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
        public void RestoreHealth(int amount = 0)
        {
            _currentHealth += amount;

            if (_currentHealth > _maxHealth)
                _currentHealth = _maxHealth;
        }

        /**
         * <inheritdoc/>
         */
        public void UpgradeHealth(int amount = 0)
        {
            _maxHealth += amount;
        }

        # endregion
    }
}
