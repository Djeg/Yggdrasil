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
    public class ControlAttackCollection : MonoDataBehaviour
    {
        # region Properties

        /**
         * <summary>
         * A reference to the hit box collection data
         * </summary>
         */
        private AttackCollectionData _attacks;

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
            Vector3 center = new Vector3(
                transform.position.x + _attacks.Hit.offsetX,
                transform.position.y + _attacks.Hit.offsetY,
                transform.position.z
            );

            Collider2D[] colliders = Physics2D.OverlapCircleAll(
                center,
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
            _attacks = GetData<AttackCollectionData>();
        }

        /**
         * <inheritdoc/>
         */
        private void OnDrawGizmosSelected()
        {
            AttackCollectionData attacks = GetData<AttackCollectionData>();

            if (null == attacks)
                return;

            attacks
                .boxes
                .FindAll(b => b.debug)
                .ForEach(b => {
                    Gizmos.color   = b.color;
                    Vector3 center = new Vector3(
                        transform.position.x + b.offsetX,
                        transform.position.y + b.offsetY,
                        transform.position.z
                    );

                    Gizmos.DrawWireSphere(center, b.radius);
                })
            ;
        }

        # endregion
    }
}
