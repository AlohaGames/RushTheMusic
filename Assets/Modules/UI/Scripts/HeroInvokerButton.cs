using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Aloha.Events;

namespace Aloha
{
    [RequireComponent(typeof(Button))]
    public class HeroInvokerButton : MonoBehaviour
    {
        public HeroType type;

        public void Awake() {
            GetComponent<Button>().onClick.AddListener(OnClick);
        }
        public void OnClick() {
            GlobalEvent.LoadHero.Invoke(type);
        }

        public void OnDestroy() {
            GetComponent<Button>().onClick.RemoveListener(OnClick);
        }
    }
}
