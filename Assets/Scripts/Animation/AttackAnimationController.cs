using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;
using Data;

namespace Animation
{
    /**
     * <summary>
     * Control the attack animation
     * </summary>
     */
    public class AttackAnimationController : StateMachineBehaviour
    {
        # region Properties

        /**
         * <summary>
         * The attacking boolean name
         * </summary>
         */
        [SerializeField]
        private string _attackingBoolName = "Attacking";

        /**
         * <summary>
         * The hit index to use
         * </summary>
         */
        [SerializeField]
        private int _hitIndex = 0;

        /**
         * <summary>
         * A reference to the hit box collection data
         * </summary>
         */
        private AttackCollectionData _attacks = null;

        /**
         * <summary>
         * A reference to the movement data
         * </summary>
         */
        private MovementData _movement = null;

        # endregion

        # region PropertyAccessors
        # endregion

        # region PublicMethods

        /**
         * <inheritdoc/>
         */
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            _attacks            = animator.GetComponent<MonoDataContainer>().GetData<AttackCollectionData>();
            _movement           = animator.GetComponent<MonoDataContainer>().GetData<MovementData>();
            _attacks.isFrozen   = true;
            _attacks.index      = _hitIndex;
            _attacks.requestHit = false;

            if (_attacks.Hit.isFrozenMovement)
                _movement.isFrozen = true;

            if (_attacks.Hit.automaticPulse)
            {
                Rigidbody2D body = animator.GetComponent<Rigidbody2D>();

                Vector2 force = _movement.direction == Direction.LEFT
                    ? -_attacks.Hit.pulseForce
                    : _attacks.Hit.pulseForce;

                body.AddForce(force, ForceMode2D.Impulse);
            }

            animator.SetBool(_attackingBoolName, true);
        }

        /**
         * <inheritdoc/>
         */
        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            _attacks.isFrozen = false;

            if (_attacks.Hit.isFrozenMovement)
                _movement.isFrozen = false;

            animator.SetBool(_attackingBoolName, false);
        }

        # endregion

        # region PrivateMethods
        # endregion
    }
}
