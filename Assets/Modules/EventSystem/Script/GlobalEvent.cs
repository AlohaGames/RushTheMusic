using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace Aloha.Events
{
    public class GlobalEvent
    {
        public static EntityEvent EntityDied = new EntityEvent();
        public static IntIntEvent OnHealthUpdate = new IntIntEvent();
        public static IntIntEvent OnHealthUpdate2 = new IntIntEvent();
        public static GameObjectEvent TileCount = new GameObjectEvent();
        public static UnityEvent LevelStop = new UnityEvent();
    }
}
