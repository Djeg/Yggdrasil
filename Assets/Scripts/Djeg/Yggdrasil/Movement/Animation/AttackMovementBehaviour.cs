using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Djeg.Yggdrasil.Movement.Component;

namespace Djeg.Yggdrasil.Movement.Animation
{
    /**
     * <summary>
     * Reset the attack movement when the animation end
     * </summary>
     */
    public class AttackMovementBehaviour : StateMachineBehaviour
    {
        # region Properties

        /**
         * <summary>
         * Does this 
         * </summary>
         */
        [SerializeField]
        private bool _resetOnStart = false;

        /**
         * <summary>
         * Attacking bool name
         * </summary>
         */
        [SerializeField]
        private string _attackingBoolName = "Attacking";

        /**
         * <summary>
         * A reference to the ControlAttackMovement
         * </summary>
         */
        private ControlAttackMovement _attack = null;

        # endregion

        # region PropertyAccessors
        # endregion

        # region PublicMethods

        /**
         * <inheritdoc/>
         */
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            _attack = animator.GetComponent<ControlAttackMovement>();

            if (_resetOnStart)
                _attack.EndAttack();

            animator.SetBool(_attackingBoolName, true);
        }

        /**
         * <inheritdoc/>
         */
        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            animator.SetBool(_attackingBoolName, false);
        }

        # endregion

        # region PrivateMethods
        # endregion
    }
}
