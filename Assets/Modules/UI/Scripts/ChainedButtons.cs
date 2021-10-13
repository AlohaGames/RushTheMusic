using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChainedButtons : MonoBehaviour
{
    public Button[] chainedButtons;

    public void Awake()
    {
        InitChained();
        for (int i = 0; i < this.chainedButtons.Length - 1; i++)
        {
            chainedButtons[i].onClick.AddListener(() => { chainedButtons[i+1].gameObject.SetActive(true); });
        }
    }

    private void InitChained(){
        chainedButtons = new Button[this.transform.childCount];
        for (int i = 0; i < this.transform.childCount; i++)
        {
            chainedButtons[i] = this.transform.GetChild(i).GetComponent<Button>();
        }
    }
}
