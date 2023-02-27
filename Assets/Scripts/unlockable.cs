using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class unlockable : MonoBehaviour
{
    public Collider2D collider;
    public bool isLocked = true;
    public UnityEvent onOpen;

    public void SetLocked(bool locked)
    {
        isLocked = locked;
    }

    public void tryOpen()
    {
        if (isLocked == false)
        {
            collider.enabled = false;
            onOpen.Invoke();
        }
    }
}
