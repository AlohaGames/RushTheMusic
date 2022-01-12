using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Aloha;

namespace Aloha.UI
{
    public class CurrentTile : MonoBehaviour
    {
        [SerializeField]
        private GameObject upLeft;
        [SerializeField]
        private GameObject upCenter;
        [SerializeField]
        private GameObject upRight;
        [SerializeField]
        private GameObject middleLeft;
        [SerializeField]
        private GameObject middleCenter;
        [SerializeField]
        private GameObject middleRight;
        [SerializeField]
        private GameObject downLeft;
        [SerializeField]
        private GameObject downCenter;
        [SerializeField]
        private GameObject downRight;


        public void LoadTile(int id, LevelMapping levelMapping)
        {
            Debug.Log("Edit Tile : " + id);
        }
    }
}
