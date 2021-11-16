using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlManager : MonoBehaviour
{
    //TODO Set mode in gameManager
    private bool leapMode = true;

    // Start is called before the first frame update
    void Start()
    {
        leapMode = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!leapMode)
        {
            float ry = Input.GetAxis("Mouse Y");
            float rx = Input.GetAxis("Mouse X");
            transform.RotateAround(this.transform.parent.transform.position, this.transform.parent.transform.up, rx);
            transform.RotateAround(this.transform.parent.transform.position, this.transform.parent.transform.right, -ry);
            CheckInputs();
        }
    }

    void CheckInputs()
    {
        if (Input.GetKeyDown(InputBinding.Instance.attack))
        {
            Debug.Log("Charge Attack");
        }
        else if (Input.GetKeyUp(InputBinding.Instance.attack))
        {
            Debug.Log("Release Attack");
        }
        else if (Input.GetKeyDown(InputBinding.Instance.defense))
        {
            Debug.Log("Charge Defense");
        }
        else if (Input.GetKeyUp(InputBinding.Instance.defense))
        {
            Debug.Log("Release Defense");
        }
    }
}
