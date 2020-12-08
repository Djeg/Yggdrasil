using System;
using UnityEngine;
using UnityEngine.Events;

namespace Event
{
    /**
     * <summary>
     * This event is dispatched when a hit on a game object happens. It received
     * two GameOject the first one is the attacker and the second is the
     * victim.
     * </summary>
     */
    [Serializable]
    public class HitEvent : UnityEvent<GameObject, GameObject>
    {
    }
}
