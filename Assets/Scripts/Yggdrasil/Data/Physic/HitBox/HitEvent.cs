using System;
using UnityEngine;
using UnityEngine.Events;
using Yggdrasil.Core.Controller;

namespace Yggdrasil.Data.Physic.HitBox
{
    /**
     * <summary>
     * This event is dispatched when a hit on a game object happens. It received
     * two MonoController the first one the attacker and the second is the
     * victim.
     * </summary>
     */
    [Serializable]
    public class HitEvent : UnityEvent<MonoController, MonoController>
    {
    }
}
