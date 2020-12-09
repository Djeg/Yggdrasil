using System;
using UnityEngine;
using Core;
using Data;
using Event;
using TMPro;

namespace Behaviour
{
    /**
     * <summary>
     * Controll the character stat data
     * </summary>
     */
    [RequireData(typeof(CharacterStatData))]
    [RequireData(typeof(AttackCollectionData))]
    public class ControlCharacterStat : MonoDataBehaviour
    {
        # region Properties

        /**
         * <summary>
         * A reference to the character stat
         * </summary>
         */
        private CharacterStatData _stat = null;

        /**
         * <summary>
         * A reference to the attack collection data
         * </summary>
         */
        private AttackCollectionData _attacks = null;

        /**
         * <summary>
         * Contains the damage display prefabs
         * </summary>
         */
        [SerializeField]
        private GameObject _damagePrefabs = null;

        # endregion

        # region PropertyAccessors
        # endregion

        # region PublicMethods
        # endregion

        # region PrivateMethods

        /**
         * <inheritdoc/>
         */
        protected override void Init(MonoDataContainer container)
        {
            _stat = GetData<CharacterStatData>();
            _attacks = GetData<AttackCollectionData>();
        }

        /**
         * <inheritdoc/>
         */
        private void OnEnable()
        {
            // Attach on event when a this object hit an other object
            _attacks.AddListener(HandleHit);
        }

        /**
         * <inheritdoc/>
         */
        private void OnDisable()
        {
            // Detach the event
            _attacks.RemoveListener(HandleHit);
        }

        /**
         * <summary>
         * This method is triggered when this object is hitting an other object.
         * </summary>
         */
        private void HandleHit(GameObject attacker, GameObject victim)
        {
            MonoDataContainer container = victim.GetComponent<MonoDataContainer>();

            if (null == container)
                return;

            CharacterStatData victimStat = container.GetData<CharacterStatData>();

            if (null == victimStat || victimStat.invincible)
                return;

            CharacterStatData.Damage damage = _stat.MakeDamage();
            victimStat.health -= damage.amount;

            victimStat.onTakingDamage.Invoke(victim, damage);

            if (null == _damagePrefabs)
                return;

            DisplayDamage(damage, victim);

            if (victimStat.IsDead)
                victimStat.onDie.Invoke(victim);
        }

        /**
         * <summary>
         * Display the damage on the victim
         * </summary>
         */
        private void DisplayDamage(CharacterStatData.Damage damage, GameObject victim)
        {
            TMP_Text text = _damagePrefabs.GetComponentInChildren<TMP_Text>();

            if (null != text)
                text.text = damage.amount.ToString();

            GameObject.Instantiate(
                _damagePrefabs,
                victim.transform.position,
                Quaternion.identity,
                victim.transform
            );
        }

        # endregion
    }
}
