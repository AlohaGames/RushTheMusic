using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Aloha.Events;
using Aloha.Hero;

namespace Aloha
{
    public class HeroInvokerButton : MonoBehaviour
    {
        public HeroType type;

        public void Awake() {
            GetComponent<Button>().onClick.AddListener(OnClick);
        }
        public void OnClick() {
            GlobalEvent.LoadHero.Invoke(type);
        }
    }
}
