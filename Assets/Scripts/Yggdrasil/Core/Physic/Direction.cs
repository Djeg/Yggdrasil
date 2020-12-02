using System.Collections;
using UnityEngine;

namespace Yggdrasil.Core.Physic
{
    /**
     * <summary>
     * Define the available direction of any object in the galme
     * </summary>
     */
    public enum Direction : int
    {
        LEFT = -1,
        RIGHT = 1,
        NONE = 0
    }

    public static class DirectionCaster
    {
        public static float ToFloat(Direction direction) => (float)(int)direction;
    }
}
