using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Aloha.Events;

public class RaiseMyEvent : MonoBehaviour
{
    public void RaiseUpdateHealth(int value) {
        GlobalEvent.OnHealthUpdate.Invoke(value,100);
    }
}
