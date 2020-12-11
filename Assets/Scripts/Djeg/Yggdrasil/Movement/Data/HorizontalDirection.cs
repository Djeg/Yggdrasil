using System.Collections;
using UnityEngine;

namespace Djeg.Yggdrasil.Movement.Data
{
    /**
     * <summary>
     * This enumeration represent an horizontal direction. You can use
     * this direction enumeration and the HorizontalDirectionHelper in order
     * to manipulate direction easily in the codebase.
     * </summary>
     */
    public enum HorizontalDirection : int
    {
        Left = -1,
        Right = 1,
        None = 0
    }
}
