using System;
using UnityEngine;
using Djeg.Yggdrasil.Persona.Behaviour;

namespace Djeg.Yggdrasil.Persona.Data
{
    /**
     * <summary>
     * Implement a static persona armor
     * </summary>
     */
    [Serializable]
    public class StaticPersonaArmor : IPersonaArmor
    {
        # region Properties

        /**
         * <summary>
         * The max armor
         * </summary>
         */
        [SerializeField]
        private int _maxArmor = 100;

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
         * Get the max armor
         * </summary>
         */
        public int MaxArmor { get => _maxArmor; }

        /**
         * <summary>
         * Get the current armor
         * </summary>
         */
        public int CurrentArmor { get => _currentArmor; }

        # endregion

        # region PublicMethods

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
        public void RestoreArmor(int amount = 0)
        {
            _currentArmor += amount;

            if (_currentArmor > _maxArmor)
                _currentArmor = _maxArmor;
        }

        /**
         * <inheritdoc/>
         */
        public void UpgradeArmor(int amount = 0)
        {
            _maxArmor += amount;
        }

        # endregion
    }
}
