using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public float spawnRate;
    public GameObject frisbee;
    public Transform frisbeeSpawn;
    float Timestamp;

	// Use this for initialization
	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Timestamp <= Time.time)
        {
            Instantiate(frisbee, frisbeeSpawn.position, frisbeeSpawn.rotation);
            Timestamp = Time.time + spawnRate;
        }
    }


}
