using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Collections;

public class Enemy : ObjectToEat
{
    public GameObject enemy;

    public EnemyMove enemyMove;

    public event Action CollidingWithPlayer;
     Vector3 initialPos;

    public Sprite enemySprite;

    public Sprite transformationSprite;

    public SpriteRenderer spriteRend;

    public bool isTransformed = false;

    public BoxCollider2D boxCol;
    
    // Start is called before the first frame update
    void Start()
    {
        foodsScoreIncrementation = 0; 
        initialPos = enemy.transform.position; 
    }

     void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (isTransformed)
            {
                foodsScoreIncrementation = 10;
                foodsScoreIncrementation++;
                enemyMove.enabled = false;
                StartCoroutine(AfterEnemyEat()); 
            }
            else
            {
                CollidingWithPlayer?.Invoke();
               
            }
            
        }
    }


    public void EnemyPosReset()
    {
        enemy.transform.position = initialPos;
        enemyMove.EnemyMovementReset();
        InitialEnemyLook();
    }

    public void TransformEnemy()
    {
        spriteRend.sprite = transformationSprite;
        isTransformed = true; 
    }

    public void InitialEnemyLook()
    {
        spriteRend.sprite = enemySprite;
        isTransformed = false;
    }

    IEnumerator AfterEnemyEat ()
    {
        int delay = 0; 
        while(delay < 1)
        {
            delay++;
            yield return new WaitForSeconds(2);
            spriteRend.enabled = true;
            enemyMove.enabled = true;
            boxCol.enabled = true;
            EnemyPosReset();
        }

        
    }
}

