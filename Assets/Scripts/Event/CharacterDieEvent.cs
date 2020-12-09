using System;
using UnityEngine;
using UnityEngine.Events;

namespace Event
{
    /**
     * <summary>
     * This event is triggered when a character die.
     * </summary>
     */
    [Serializable]
    public class CharacterDieEvent : UnityEvent<GameObject>
    {
    }
}
