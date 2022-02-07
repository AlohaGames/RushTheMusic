using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aloha
{
    public class DontDestroy : MonoBehaviour
    {
        [HideInInspector]
        public string ObjectID;

        private void Awake()
        {
            ObjectID = name + transform.position.ToString() + transform.eulerAngles.ToString();
        }
        private void Start()
        {
            transform.SetParent(null);
            DontDestroy[] dontDestroys = FindObjectsOfType<DontDestroy>();
            foreach (DontDestroy dontDestroy in dontDestroys)
            {
                if (dontDestroy != this)
                {
                    if (dontDestroy.ObjectID == this.ObjectID)
                    {
                        Destroy(gameObject);
                    }
                }
            }
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
