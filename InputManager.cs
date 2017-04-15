using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    public GameObject playerObject;
    private PlayerController controller;

    // Use this for initialization
    void Start()
    {
        controller = playerObject.GetComponent<PlayerController>();
    }
	
    // Update is called once per frame
    void Update()
    {
        controller.MoveRight(Input.GetKey(KeyCode.D));
        controller.MoveLeft(Input.GetKey(KeyCode.A));
        controller.MoveUp(Input.GetKey(KeyCode.W));
        controller.MoveDown(Input.GetKey(KeyCode.S));
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            controller.Block();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            controller.Attack();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            controller.Die();
        }

    }
}
