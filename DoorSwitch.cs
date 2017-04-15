using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSwitch : MonoBehaviour
{

    public GameObject doorObject;

    private DoorController doorController;
    private bool playerNearby = false;
    // Use this for initialization
    void Start()
    {
        this.doorController = this.doorObject.GetComponent<DoorController>();
    }
	
    // Update is called once per frame
    void Update()
    {
        if (playerNearby && Input.GetKeyDown(KeyCode.E))
        {
            doorController.SetOpen(!doorController.open);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            playerNearby = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            playerNearby = false;
        }
    }
}
