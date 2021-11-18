using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Aloha
{
    /// <summary>
    /// It's an abstract class which represent all the items
    /// </summary>
    public abstract class Item
    {
        /// <summary>
        /// It's the effect of the item
        /// </summary>
        public abstract void Effect();
    }
}
