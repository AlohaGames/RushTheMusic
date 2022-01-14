using UnityEngine;
using UnityEngine.Events;

namespace Aloha.Events
{
    /// <summary>
    /// Class for a HUD Effect Event
    /// </summary>
    public class HUDEffectEvent : UnityEvent<float, float, HUDEffectType> { }
}
