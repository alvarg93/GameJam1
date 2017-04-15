using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingDoor : DoorController
{
    public Vector3 openRotation = new Vector3(0, 0, 90);
    public Vector3 closedRotation = new Vector3(0, 0, 0);

    // Use this for initialization
    void Start()
    {

    }

    void Update()
    {
        if (open)
        {
            if (this.transform.localEulerAngles.z < 90)
            {
                this.transform.RotateAround(this.transform.position, Vector3.forward, speed * Time.deltaTime);
            }
            else
            {
                this.transform.localEulerAngles = openRotation;
            }
        }
        else
        {
            Vector3 rotationAngles = this.transform.localEulerAngles;
            if (rotationAngles.z > 0 && rotationAngles.z <= 90)
            {
                this.transform.RotateAround(this.transform.position, Vector3.forward, -speed * Time.deltaTime);
            }
            else
            {
                this.transform.localEulerAngles = closedRotation;
            }

        }
    }
}