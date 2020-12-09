using System;
using UnityEngine;
using Core;
using Data;

namespace Behaviour
{
    /**
     * <summary>
     * Control the behaviour of a collection of hit boxes.
     * </summary>
     */
    [RequireData(typeof(AttackCollectionData))]
    [RequireData(typeof(MovementData))]
    public class ControlAttackCollection : MonoDataBehaviour
    {
        # region Properties

        /**
         * <summary>
         * A reference to the hit box collection data
         * </summary>
         */
        private AttackCollectionData _attacks;

        /**
         * <summary>
         * The movement data
         * </summary>
         */
        private MovementData _movement;

        # endregion

        # region PropertyAccessors
        # endregion

        # region PublicMethods

        /**
         * <summary>
         * Request hits
         * </summary>
         */
        public void TriggerHit()
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(
                GetCenter(),
                _attacks.Hit.radius,
                _attacks.layer
            );

            foreach (Collider2D collider in colliders)
            {
                GameObject attacker = gameObject;
                GameObject victim = collider.gameObject;

                _attacks.Hit.onHit.Invoke(attacker, victim);
            }
        }

        /**
         * <summary>
         * Reset the hit box collection index
         * </summary>
         */
        public void ResetHit()
        {
            _attacks.index = 0;
        }

        /**
         * <summary>
         * Freeze the ability to hit
         * </summary>
         */
        public void FreezeHit()
        {
            _attacks.isFrozen = true;
        }

        /**
         * <summary>
         * Unfreeze the ability to hit
         * </summary>
         */
        public void UnfreezeHit()
        {
            _attacks.isFrozen = false;
        }

        # endregion

        # region PrivateMethods

        /**
         * <inheritdoc/>
         */
        protected override void Init(MonoDataContainer container)
        {
            _attacks  = GetData<AttackCollectionData>();
            _movement = GetData<MovementData>();
        }

        /**
         * <inheritdoc/>
         */
        private void OnEnable()
        {
            _attacks.AddListener(HandleAttackForce);
        }

        /**
         * <inheritdoc/>
         */
        private void OnDisable()
        {
            _attacks.RemoveListener(HandleAttackForce);
        }

        /**
         * <inheritdoc/>
         */
        private void OnDrawGizmosSelected()
        {
            if (null == _attacks)
                _attacks = GetData<AttackCollectionData>();

            int index = 0;

            _attacks
                .boxes
                .FindAll(b => b.debug)
                .ForEach(b => {
                    Gizmos.color   = b.color;
                    Vector3 center = GetCenter(index);

                    Gizmos.DrawWireSphere(center, b.radius);

                    index += 1;
                })
            ;
        }

        /**
         * <summary>
         * Retrieve the center point of the circle collider
         * </summary>
         */
        private Vector3 GetCenter() => GetCenter(_attacks.index);
        private Vector3 GetCenter(int index)
        {
            if (null == _movement)
                _movement = GetData<MovementData>();

            if (null == _attacks)
                _attacks = GetData<AttackCollectionData>();

            AttackData hit = _attacks.boxes[index];

            return transform.position + hit.GetOffset(_movement.direction);
        }

        /**
         * <summary>
         * Handle the attack force on a victim
         * </summary>
         */
        private void HandleAttackForce(GameObject attacker, GameObject victim)
        {
            Rigidbody2D body = victim.GetComponent<Rigidbody2D>();

            if (null == body)
                return;

            body.AddForce(_attacks.Hit.GetForce(_movement.direction), ForceMode2D.Impulse);
        }

        # endregion
    }
}
