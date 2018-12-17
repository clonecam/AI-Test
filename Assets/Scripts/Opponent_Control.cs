using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opponent_Control : MonoBehaviour
{

    public GameObject Frisbee;
    public float MoveSpeed = 4;
    Rigidbody rb;
    

    void Start()
    {
        rb = Frisbee.GetComponent<Rigidbody>();
    }

    void Update()
    {
         //Vector3 lookVector = Frisbee.transform.position - transform.position;
         //lookVector.y = transform.position.y;
         //Quaternion rot = Quaternion.LookRotation(lookVector);
         //transform.rotation = Quaternion.Slerp(transform.rotation, rot, 1);

        if (Frisbee.transform.position.z >= 0 && rb.velocity.y >= 1)
        {

            transform.position += transform.forward * MoveSpeed * Time.deltaTime;

        }
        //Debug.Log(rb.velocity.z);
        //Debug.Log(rb.velocity.y);
        //Debug.Log(rb.velocity.x);
    }
}
