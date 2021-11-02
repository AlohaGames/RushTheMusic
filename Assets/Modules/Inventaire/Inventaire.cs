using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aloha
{
    public class Inventaire : MonoBehaviour
    {

        private Queue<Item> items;


        public void useItem()
        {
            Item item = items.Dequeue();
            item.effect();
        }

        public Queue<Item> getItems()
        {
            return items;
        }
    }
}

