using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Aloha
{
    public class HealPotion : Item
    {
        private int gain;

        public HealPotion(int gain)
        {
            this.gain = gain;
        }

        public override void Effect()
        {
            Hero hero = GameManager.Instance.GetHero();
            hero.Regeneration(this.gain);
        } 
    }
}

