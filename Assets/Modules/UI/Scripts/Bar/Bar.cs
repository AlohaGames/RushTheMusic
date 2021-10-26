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
        public Color color;

        public void Start()
        {
            bar = transform.GetChild(0).gameObject;
            bar.GetComponent<Image>().color = color;
        }

        public abstract void UpdateBar(int current, int max);
    }
}
