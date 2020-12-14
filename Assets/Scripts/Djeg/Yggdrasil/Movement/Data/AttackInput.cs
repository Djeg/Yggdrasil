using System;
using UnityEngine;

namespace Djeg.Yggdrasil.Movement.Data
{
    /**
     * <summary>
     * Represet the input sent to the messages when hitting
     * someone
     * </summary>
     */
    [Serializable]
    public struct AttackInput
    {
        # region Properties

        /**
         * <summary>
         * The victim
         * </summary>
         */
        public GameObject victim;

        /**
         * <summary>
         * The attack concerned attack
         * </summary>
         */
        public Attack attack;

        # endregion

        # region PropertyAccessors
        # endregion
    }
}
