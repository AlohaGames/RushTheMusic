using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Aloha
{
    /// <summary>
    /// This class manage the item
    /// </summary>
    public abstract class Item : MonoBehaviour
    {
        public Sprite itemSprite;        

        /// <summary>
        /// Give an effect to an item
        /// </summary>
        public abstract void Effect();
    }
}
