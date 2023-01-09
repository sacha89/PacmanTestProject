using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 

public class Enemy : MonoBehaviour
{
    public GameObject enemy;

    public EnemyMove enemyMove;

    public event Action CollidingWithPlayer;
     Vector3 initialPos; 
    
    
    // Start is called before the first frame update
    void Start()
    {
        initialPos = enemy.transform.position; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            CollidingWithPlayer?.Invoke(); 
           Debug.Log("EnemyCollision");
        }
    }

    public void EnemyPosReset()
    {
        enemy.transform.position = initialPos;
        enemyMove.EnemyMovementReset();
    }


}

