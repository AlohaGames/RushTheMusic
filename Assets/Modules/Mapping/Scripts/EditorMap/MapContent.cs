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

        [SerializeField]
        private Sprite lockSprite;


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
            if (numTiles > 0)
            {
                (this.transform as RectTransform).sizeDelta = new Vector2(260 * (numTiles + 10), 630);
                tileNumber.text = ((int) numTiles + 1).ToString();
                EditorManager.Instance.SetTilesCount((int) numTiles + 10);
                for (int i = 0; i < numTiles + 10; i++)
                {
                    GameObject p = Instantiate(panel);
                    p.transform.SetParent(this.transform);
                    p.transform.localScale = Vector3.one;
                    if (i < 4 || i > numTiles)
                    {
                        AddLock(p);
                    }
                    Text text = Instantiate(panelNum);
                    text.text = i.ToString();
                    p.GetComponent<SelectTile>().SetId(i);
                    text.transform.SetParent(this.transform);
                    text.transform.localScale = Vector3.one;
                }
            }

            EditorManager.Instance.NeedUpdate();
        }

        void AddLock(GameObject panel)
        {
            panel.GetComponent<Button>().enabled = false;
            panel?.transform.Clear();
            GameObject preimage = new GameObject("image_empty");
            GameObject image = new GameObject("image_lock");
            GameObject postimage = new GameObject("image_empty");
            preimage.AddGetComponent<Image>();
            image.AddGetComponent<Image>().sprite = lockSprite;
            postimage.AddGetComponent<Image>();
            preimage.transform.SetParent(panel?.transform);
            image.transform.SetParent(panel?.transform);
            postimage.transform.SetParent(panel?.transform);
            image.transform.localPosition = new Vector3(0, 0, 0);
            image.transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}
