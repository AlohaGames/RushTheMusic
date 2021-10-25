using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Aloha.Events;
using UnityEngine.UI;

namespace Aloha
{
    public abstract class Bar : MonoBehaviour
    {
        protected GameObject bar;
        public GameObject hero;
        public Color color;

        public IntIntEvent updateEvent;

        public void Init(IntIntEvent updateEvent)
        {
            this.updateEvent = updateEvent;
            bar = transform.GetChild(0).gameObject;
            bar.GetComponent<Image>().color = color;
            this.updateEvent.AddListener(UpdateBar);
        }

        public abstract void UpdateBar(int current, int max);

        public void OnDestroy()
        {
            updateEvent?.RemoveListener(UpdateBar);
        }
    }
}