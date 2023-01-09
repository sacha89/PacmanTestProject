using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public List<Transform> waypoints;
    int currentWaypoin = 0;

    public float enemySpeed = 0.075f; 

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position != waypoints[currentWaypoin].position)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, waypoints[currentWaypoin].position, enemySpeed * Time.deltaTime); 
        }

        else
        {
            currentWaypoin = (currentWaypoin + 1) % waypoints.Count; 
        }
    }

    public void EnemyMovementReset()
    {
        currentWaypoin = 0;
    }
}
