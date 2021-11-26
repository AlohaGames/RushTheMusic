using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoProfilPickerUI : MonoBehaviour
{
    void Start()
    {
        Button create = GetComponentInChildren<Button>();
        create.onClick.AddListener(onCreate);
    }

    private void onCreate()
    {
        this.transform.parent.transform.parent.GetChild(1).gameObject.SetActive(true);
    }
}
