using UnityEngine;
using UnityEngine.Events;
using Aloha.Hero;
using Aloha.EntityStats;

namespace Aloha.Events
{
    public class HeroEvent : UnityEvent<Hero<HeroStats>>
    {


    }
}