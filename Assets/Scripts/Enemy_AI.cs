using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AI : MonoBehaviour
{

    public Transform target;

    private Vector3 moveDirection;
    public float speed = 25f;
    private CharacterController controller;
    private float ran;
    private float timeStamp;
    private float stopTime;

    // Use this for initialization
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        ran = Random.Range(1, 3);
        int LayerMask = 1 << 9;
        LayerMask = ~LayerMask;
        timeStamp = Random.Range(1, 7);

        Debug.Log(timeStamp);
        Debug.Log(Time.deltaTime);
        //Debug.Log(ran);


        if (ran == 1 && timeStamp <= Time.time)
        {
            Walk();
            timeStamp = timeStamp + Time.time;
            Debug.Log("walk");
        }

        if (ran == 2 && timeStamp <= Time.time)
        {
            Turn();
            timeStamp = timeStamp + Time.time;
            Debug.Log("turn");
        }


        if (Physics.Linecast(transform.position, target.position, LayerMask))
        {
            Debug.Log("blocked");
            Debug.DrawLine(transform.position, target.position, Color.red);
        }

        else
        {
            Debug.DrawLine(transform.position, target.position, Color.green);
        }
    }


    void Walk()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        if (stopTime <= Time.time)
        {
            //controller.SimpleMove(4f);
        }
    }

    void Turn()
    {
        if(Random.Range(1,2) == 1)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0f, 90f, 0f));
        }

        else
        {
            transform.rotation = Quaternion.Euler(new Vector3(0f, -90f, 0f));
        }
    }


}
