using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Aloha;

namespace Aloha.UI
{
    public class MapContent : MonoBehaviour
    {
        public EditorRoot Root;
        [SerializeField]
        private GameObject panel;

        [SerializeField]
        private Text panelNum;

        private Text tileNumber;

        // Duration of the music (in seconds)
        [SerializeField]
        private float duration = 0;

        // number of tiles during one second
        [SerializeField]
        private float tileSpeed = 7;

        // size of the tiles
        [SerializeField]
        private float titleSize = 5;


        private void Awake()
        {
            tileNumber = Root.Information.NbTiles;
        }

        private void Start()
        {
            UpdateNumTiles();
        }

        public void SetDuration(float duration)
        {
            this.duration = duration;
            UpdateNumTiles();
        }

        void UpdateNumTiles()
        {
            this.transform.Clear();
            float numTiles = ((this.duration * this.tileSpeed) / this.titleSize);
            tileNumber.text = ((int) numTiles + 1).ToString();
            EditorManager.Instance.SetTilesCount((int) numTiles + 1);
            for (int i = 0; i < numTiles; i++)
            {
                GameObject p = Instantiate(panel);
                p.transform.SetParent(this.transform);
                Text text = Instantiate(panelNum);
                text.text = i.ToString();
                p.GetComponent<SelectTile>().SetId(i);
                text.transform.SetParent(this.transform);
            }
            EditorManager.Instance.NeedUpdate();
        }
    }
}
