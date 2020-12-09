using System;
using UnityEngine;
using UnityEngine.Events;

namespace Event
{
    /**
     * <summary>
     * This event happens when a character is healing of a given amount.
     * </summary>
     */
    [Serializable]
    public class CharacterHealEvent : UnityEvent<GameObject, int>
    {
    }
}
