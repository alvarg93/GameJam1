using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{

    public bool open = false;
    public float speed = 1.0f;

    public virtual void SetOpen(bool open)
    {
        this.open = open;
    }
}
