using System.Collections;
using UnityEngine;

namespace Yggdrasil.Core.Physic
{
    /**
     * <summary>
     * Define the available direction of any object in the game
     * </summary>
     */
    public enum Direction : int
    {
        LEFT = -1,
        RIGHT = 1,
        NONE = 0
    }

    public static class DirectionHelper
    {
        public static float ToFloat(Direction direction) => (float)(int)direction;

        public static Direction Inverse(Direction direction) =>
            direction == Direction.RIGHT
                ? Direction.LEFT
                : direction == Direction.LEFT
                    ? Direction.RIGHT
                    : Direction.NONE
        ;
    }
}
