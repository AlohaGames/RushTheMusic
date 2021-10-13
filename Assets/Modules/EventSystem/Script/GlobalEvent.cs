using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace Aloha.Events
{
    public class GlobalEvent
    {
        public static EntityEvent EntityDied = new EntityEvent();
        public static GameObjectEvent TileCount = new GameObjectEvent();
        public static UnityEvent LevelStop = new UnityEvent();
        public static UnityEvent LevelStart = new UnityEvent();
        public static StringEvent LoadLevel = new StringEvent();
    }
}