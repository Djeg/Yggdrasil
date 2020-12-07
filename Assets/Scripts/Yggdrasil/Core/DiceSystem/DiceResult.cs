using System;
using UnityEngine;

namespace Yggdrasil.Core.DiceSystem
{
    /**
     * <summary>
     * Represent the result of a Dice roll
     * </summary>
     */
    public struct DiceResult
    {
        # region Properties

        /**
         * <summary>
         * The value rolled by the dice
         * </summary>
         */
        public int result;

        /**
         * <summary>
         * The dice instance used to obtain this roll.
         * </summary>
         */
        public Dice dice;

        /**
         * <summary>
         * Test of the result has been critical or not
         * </summary>
         */
        public bool isCritical;

        # endregion

        # region PropertyAccessors
        # endregion
    }
}
