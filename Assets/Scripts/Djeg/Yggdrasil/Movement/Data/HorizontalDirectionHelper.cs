using System.Collections;
using UnityEngine;

namespace Djeg.Yggdrasil.Movement.Data
{
    /**
     * <summary>
     * This class helps you interact and build direction in your code base.
     * </summary>
     */
    public static class HorizontalDirectionHelper
    {
        # region PublicMethods

        /**
         * <summary>
         * Inverse an horizontal direction
         * </summary>
         */
        public static HorizontalDirection Inverse(HorizontalDirection direction) =>
            direction == HorizontalDirection.Left
                ? HorizontalDirection.Right
                : direction == HorizontalDirection.Right
                    ? HorizontalDirection.Left
                    : HorizontalDirection.None
        ;

        /**
         * <summary>
         * Convert a direction into it's according float. -1 for left, 1 for right
         * and 0 for None.
         * </summary>
         */
        public static float ToFloat(HorizontalDirection direction) =>
            (float)(int)direction
        ;

        /**
         * <summary>
         * Convert a direction into a Vector2
         * </summary>
         */
        public static Vector2 ToVector2(HorizontalDirection direction) =>
            direction == HorizontalDirection.Left
                ? Vector2.left
                : direction == HorizontalDirection.Right
                    ? Vector2.right
                    : Vector2.zero
        ;

        /**
         * <summary>
         * Parse a direction and a float value by negating the float value
         * when going left.
         * </summary>
         */
        public static float Parse(HorizontalDirection direction, float value) =>
            direction == HorizontalDirection.Left
                ? -value
                : value
        ;

        /**
         * <summary>
         * Convert a float to a direction
         * </summary>
         */
        public static HorizontalDirection FromFloat(float value, HorizontalDirection currentDirection = HorizontalDirection.None) =>
            value > 0f
                ? HorizontalDirection.Right
                : value < 0f
                    ? HorizontalDirection.Left
                    : currentDirection
        ;

        # endregion
    }
}
