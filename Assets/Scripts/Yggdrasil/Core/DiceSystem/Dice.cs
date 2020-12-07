using System;

namespace Yggdrasil.Core.DiceSystem
{
    /**
     * <summary>
     * Represent a dice that you can roll
     * </summary>
     */
    public struct Dice
    {
        # region Properties

        /**
         * <summary>
         * A simple static reference to an instance of Random
         * </summary>
         */
        private static Random _random = new Random();

        /**
         * <summary>
         * The dice face
         * </summary>
         */
        public DiceFace face;

        /**
         * <summary>
         * Determine of how much the max value of this dice should be
         * decrement in order to have a critical. The formula is 
         *
         * MaxFace - criticalModifer == CriticalRoll
         * </summary>
         * <example>
         * For a dice of 6 face and a criticalModifier of 0, when a 6 is rolled
         * then the result will be considered as a critical. But if the roll
         * is 5 then it will not be critical.
         * For a dice of 12 faces and a criticalModifier of 1 then 11 and 12
         * will be considered as critical.
         * </example>
         */
        public int criticalModifier;

        # endregion

        # region PublicMethods

        /**
         * <summary>
         * Create a dice
         * </summary>
         */
        Dice(DiceFace _face = DiceFace.SIX, int _criticalModifier = 0)
        {
            face             = _face;
            criticalModifier = _criticalModifier > (int)face
                ? (int)face
                : _criticalModifier
            ;
        }

        /**
         * <summary>
         * Roll the dice and return a dice result
         * </summary>
         */
        public DiceResult Roll()
        {
            int result      = _random.Next(1, (int)face);
            bool isCritical = result >= (int)face - criticalModifier;

            return new DiceResult {
                dice       = this,
                isCritical = isCritical,
                result     = result
            };
        }

        # endregion
    }
}
