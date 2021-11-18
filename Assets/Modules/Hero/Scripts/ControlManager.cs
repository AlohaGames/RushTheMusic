using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aloha
{
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
        if (!leapMode && GameManager.Instance.GetIsPlaying())
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
            PrepareAttack();
        }
        else if (Input.GetKeyUp(InputBinding.Instance.attack))
        {
            ReleaseAttack();
        }
        else if (Input.GetKeyDown(InputBinding.Instance.defense))
        {
            PrepareDefense();
        }
        else if (Input.GetKeyUp(InputBinding.Instance.defense))
        {
            ReleaseDefense();
        }
    }

    protected virtual void PrepareAttack() { }

    protected virtual void ReleaseAttack() { }

    protected virtual void PrepareDefense() { }

    protected virtual void ReleaseDefense() { }
    }
}
