using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingDoor : DoorController
{
    public float positionXClosed = 0f;
    public float positionXOpen = 20f;

    void Update()
    {
        if (open)
        {
            if (this.transform.localPosition.x < positionXOpen)
            {
                this.transform.localPosition += new Vector3(speed * Time.deltaTime, 0, 0);
            }
            else
            {
                this.transform.localPosition = new Vector3(positionXOpen, this.transform.localPosition.y , this.transform.localPosition.z);
            }
        }
        else
        {
            if (this.transform.localPosition.x > positionXClosed)
            {
                this.transform.localPosition -= new Vector3(speed * Time.deltaTime, 0, 0);
            }
            else
            {
                this.transform.localPosition = new Vector3(positionXClosed, this.transform.localPosition.y , this.transform.localPosition.z);
            }
        }
    }
}
