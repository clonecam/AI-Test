using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_AI_2 : MonoBehaviour
{

    public Transform playerCharacter;

    private LineRenderer line;

    public float wanderRadius;
    public float wanderTimer;

    private readonly Transform target;
    private NavMeshAgent agent;
    private float timer;


    // Use this for initialization
    void OnEnable()
    {
        agent = GetComponent<NavMeshAgent>();
        timer = wanderTimer;
        line = GetComponent<LineRenderer>();
        line.enabled = false;
        line.material.color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        int LayerMask = 1 << 9;
        LayerMask = ~LayerMask;
        RaycastHit hitInfo;
        float theDistance;

        Vector3 targetDir = playerCharacter.position - transform.position;
        float angleToPlayer = (Vector3.Angle(targetDir, transform.forward));

        if (timer >= wanderTimer)
        {
            Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
            agent.SetDestination(newPos);
            timer = 0;
        }

        if (Physics.Linecast(transform.position, playerCharacter.position, LayerMask))
        {
            //Debug.Log("blocked");
            Debug.DrawLine(transform.position, playerCharacter.position, Color.red);
            line.enabled = false;
        }

        else
        {
            Physics.Linecast(transform.position, playerCharacter.position, out hitInfo);
            Debug.DrawLine(transform.position, playerCharacter.position, Color.green);
            theDistance = hitInfo.distance;
            //Debug.Log(theDistance + " " + hitInfo.collider.gameObject.name);
            line.enabled = false;
            if (theDistance <= 10f && angleToPlayer >= -90 && angleToPlayer <= 90)
            {
                Debug.Log("player is in sight!!");
                line.enabled = true;
                line.SetPosition(0, transform.position);
                line.SetPosition(1, playerCharacter.position);
                
            }
        }
    }

    

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
    }
}
