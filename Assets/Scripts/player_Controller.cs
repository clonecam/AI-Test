using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_Controller : MonoBehaviour
{
    public float maxSpeed = 6f;
    public float timeZeroToMax = 2.5f;
    private float accelRatePerSec;
    private float forwardVelocity;
    public float minX = -13.75f;
    public float maxX = 13.75f;
    public float minZ = -1f;
    public float maxZ = -24f;


    // Use this for initialization
    void Start ()
    {
        accelRatePerSec = maxSpeed / timeZeroToMax;
        forwardVelocity = 0f;
    }
	
	// Update is called once per frame
	void Update ()
    {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 20f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 20f;

        //transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX), 3f, Mathf.Clamp(transform.position.z, minZ, maxZ));
        transform.Translate(x, 0, 0);
        transform.Translate(0, 0, z);


        Debug.Log(transform.position.z);
    }

    void OnCollisionEnter(Collision collision)
    {
        //Output the Collider's GameObject's name
        Debug.Log(collision.collider.name);
    }
}
