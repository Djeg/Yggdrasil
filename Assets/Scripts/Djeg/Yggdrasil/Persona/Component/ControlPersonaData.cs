using System.Collections;
using UnityEngine;
using Djeg.Yggdrasil.Persona.Data;
using Djeg.Yggdrasil.Persona.Behaviour;
using Djeg.Yggdrasil.Movement.Component;

namespace Djeg.Yggdrasil.Persona.Component
{
    /**
     * <summary>
     * Control a persona data.
     * </summary>
     */
    [RequireComponent(typeof(ControlAttackMovement))]
    public class ControlPersonaData : MonoBehaviour, IPersonaHealth, IPersonaArmor, IPersonaDamage
    {
        # region Properties

        /**
         * <summary>
         * A random instanec
         * </summary>
         */
        private static System.Random _random = new System.Random();

        /**
         * <summary>
         * The max heath
         * </summary>
         */
        [SerializeField]
        [Header("Health")]
        private int _maxHealth = 100;

        /**
         * <summary>
         * the current health
         * </summary>
         */
        [SerializeField]
        private int _currentHealth = 100;

        /**
         * <summary>
         * The max armor
         * </summary>
         */
        [SerializeField]
        [Header("Armor")]
        private int _maxArmor = 100;

        /**
         * <summary>
         * The current armor
         * </summary>
         */
        [SerializeField]
        private int _currentArmor = 100;

        /**
         * <summary>
         * The max damage
         * </summary>
         */
        [SerializeField]
        [Header("Damage")]
        private int _maxDamage = 20;

        /**
         * <summary>
         * The minimum damage
         * </summary>
         */
        [SerializeField]
        private int _minDamage = 20;

        /**
         * <summary>
         * The critical range
         * </summary>
         */
        [SerializeField]
        private int _criticalRange = 18;

        /**
         * <summary>
         * The critical modifier
         * </summary>
         */
        [SerializeField]
        private int _criticalModifier = 2;

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

        /**
         * <summary>
         * Get the armor
         * </summary>
         */
        public int MaxArmor { get => _maxArmor; }

        /**
         * <summary>
         * Get the current armot
         * </summary>
         */
        public int CurrentArmor { get => _currentArmor; }

        /**
         * <summary>
         * Get and se the max damage
         * </summary>
         */
        public int MaxDamage
        {
            get => _maxDamage;
            set => _maxDamage = value;
        }

        /**
         * <summary>
         * Get and set the minimum damage
         * </summary>
         */
        public int MinDamage
        {
            get => _minDamage;
            set => _minDamage = value;
        }

        /**
         * <summary>
         * Get and set the critical range
         * </summary>
         */
        public int CriticalRange
        {
            get => _criticalRange;
            set => _criticalRange = value;
        }

        /**
         * <summary>
         * Get and set the critical modifier
         * </summary>
         */
        public int CriticalModifier
        {
            get => _criticalModifier;
            set => _criticalModifier = value;
        }

        # endregion

        # region PublicMethods

        /**
         * <inheritdoc/>
         */
        public void DamageHealth(PersonaDamage damage)
        {
            int newHealth = _currentHealth - damage.amount;
            bool isDead = newHealth <= 0 && _currentHealth > 0;

            if (newHealth < 0)
                newHealth = 0; 

            _currentHealth = newHealth;

            if (isDead)
                BroadcastMessage("OnDie", SendMessageOptions.DontRequireReceiver);
        }

        /**
         * <inheritdoc/>
         */
        public void DamageArmor(PersonaDamage damage)
        {
            int newArmor = _currentArmor - damage.amount;
            int healthDamage = newArmor < 0 ? Mathf.Abs(newArmor) : 0;
            bool isBrokenArmor = newArmor <= 0 && _currentArmor > 0;

            _currentArmor = newArmor;

            if (_currentArmor < 0)
                _currentArmor = 0;

            if (isBrokenArmor)
                BroadcastMessage("OnArmorBroken", SendMessageOptions.DontRequireReceiver);

            if (healthDamage > 0)
                DamageHealth(new PersonaDamage {
                    amount = healthDamage,
                    critical = damage.critical
                });
        }

        /**
         * <inheritdoc/>
         */
        public void RestoreHealth(int amount = 0)
        {
            if (_currentHealth >= _maxHealth)
                return;

            _currentHealth += amount;

            if (_currentHealth > _maxHealth)
                _currentHealth = _maxHealth;

            BroadcastMessage("OnHealthRestored", SendMessageOptions.DontRequireReceiver);
        }

        /**
         * <inheritdoc/>
         */
        public void RestoreArmor(int amount = 0)
        {
            if (_currentArmor >= _maxArmor)
                return;

            _currentArmor += amount;

            if (_currentArmor > _maxArmor)
                _currentArmor = _maxArmor;

            BroadcastMessage("OnArmorRestored", SendMessageOptions.DontRequireReceiver);
        }

        /**
         * <inheritdoc/>
         */
        public void UpgradeHealth(int amount = 0)
        {
            _maxHealth += amount;

            BroadcastMessage("OnHealthUpgraded", SendMessageOptions.DontRequireReceiver);
        }

        /**
         * <inheritdoc/>
         */
        public void UpgradeArmor(int amount = 0)
        {
            _maxArmor += amount;

            BroadcastMessage("OnArmorUpgraded", SendMessageOptions.DontRequireReceiver);
        }

        /**
         * <inheritdoc/>
         */
        public PersonaDamage RollDamage()
        {
            int amount = _random.Next(MinDamage, MaxDamage + 1);
            bool isCritical = amount >= CriticalRange;

            if (isCritical)
                amount = amount * CriticalModifier;

            return new PersonaDamage {
                amount = amount,
                critical = isCritical
            };
        }

        # endregion

        # region PrivateMethods

        /**
         * <summary>
         * When this object is hitting an other object
         * </summary>
         */
        private void OnHit(GameObject victim)
        {
            IPersonaArmor armor = victim.GetComponent<IPersonaArmor>();
            IPersonaHealth health = victim.GetComponent<IPersonaHealth>();

            if (null == armor && null == health)
                return;

            PersonaDamage damage = RollDamage();

            if (null == armor)
                armor.DamageArmor(damage);
            else
                health.DamageHealth(damage);
        }

        # endregion
    }
}
