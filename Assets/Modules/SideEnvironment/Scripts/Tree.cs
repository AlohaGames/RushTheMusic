using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aloha
{
    public class Tree : SideEnvironment
    {

        [SerializeField] float MAX_TREE_HEIGHT;

        public override void Initialize()
        {
            height = Utils.RandomFloat(1, MAX_TREE_HEIGHT);
        }
    }
}
