using System.Collections;
using System.Collections.Generic;
using Data;
using UnityEngine;
using Core;

namespace Animation
{
    /**
     * <summary>
     * Control the Hurt animation
     * </summary>
     */
    public class FrozenAnimationController : StateMachineBehaviour
    {
        # region Properties

        /**
         * <summary>
         * Make the character invincible during all the animation
         * </summary>
         */
        [SerializeField]
        private bool _makeInvincible = false;

        /**
         * <summary>
         * A reference to the movement data
         * </summary>
         */
        private MovementData _movement = null;

        /**
         * <summary>
         * A reference to the character stat data
         * </summary>
         */
        private CharacterStatData _stat = null;

        /**
         * <summary>
         * A reference to the attack collection data
         * </summary>
         */
        private AttackCollectionData _attacks = null;

        # endregion

        # region PropertyAccessors
        # endregion

        # region PublicMethods

        /**
         * <inheritdoc/>
         */
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            _movement = animator.GetComponent<MonoDataContainer>().GetData<MovementData>();
            _stat     = animator.GetComponent<MonoDataContainer>().GetData<CharacterStatData>();
            _attacks  = animator.GetComponent<MonoDataContainer>().GetData<AttackCollectionData>();

            _movement.isFrozen = true;
            _attacks.isFrozen  = true;
            _stat.invincible   = _makeInvincible;
        }

        /**
         * <inheritdoc/>
         */
        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            _movement.isFrozen = false;
            _stat.invincible   = false;
            _attacks.isFrozen  = false;
        }

        # endregion

        # region PrivateMethods
        # endregion
    }
}
