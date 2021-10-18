using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace Aloha.Events
{
    public class GlobalEvent
    {
        public static EntityEvent EntityDied = new EntityEvent();
        public static HeroEvent HeroHealth = new HeroEvent();
    }
}