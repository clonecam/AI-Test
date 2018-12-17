using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AI_3 : MonoBehaviour
{
    public Transform player;

    private void Update()
    {
        Vector3 targetDir = player.position - transform.position;
        float angleToPlayer = (Vector3.Angle(targetDir, transform.forward));


        if (angleToPlayer >= -90 && angleToPlayer <= 90) // 180° FOV
        {
            Debug.Log("Player in sight!");
        }
    }
    
}