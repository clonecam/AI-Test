using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Cont_AI_Test : MonoBehaviour
{


    private Vector3 moveDirection;
    public float speed = 25f;
    private CharacterController controller;

    // Use this for initialization
    void Start ()
    {
        controller = GetComponent<CharacterController>();
    }
	
	// Update is called once per frame
	void Update ()
    {

        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection = moveDirection * speed;

        controller.Move(moveDirection * Time.deltaTime);

    }
}
