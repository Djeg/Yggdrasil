using System;
using UnityEngine;
using UnityEngine.Events;
using Data;

namespace Event
{
    /**
     * <summary>
     * This event is triggered when a character is taking damage.
     * </summary>
     */
    [Serializable]
    public class CharacterDamageEvent : UnityEvent<GameObject, CharacterStatData.Damage>
    {
    }
}
