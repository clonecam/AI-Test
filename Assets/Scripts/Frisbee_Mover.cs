using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frisbee_Mover : MonoBehaviour
{

    Rigidbody rb;
    public float speed;

	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody>();
        transform.Rotate(new Vector3(0f, Random.Range(120f, 260f), 0f));
        rb.velocity = transform.forward * speed;
    }
	
	// Update is called once per frame
	void Update ()
    {
        //Debug.Log(rb.velocity.z);
        //Debug.Log(rb.velocity.y);
        //Debug.Log(rb.velocity.x);
    }

    private void FixedUpdate()
    {
        
    }
}
