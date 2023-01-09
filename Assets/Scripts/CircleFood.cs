using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CircleFood : ObjectToEat
{

    public event Action TransformEnemy; 

    // Start is called before the first frame update
    void Start()
    {
        foodsScoreIncrementation = 5; 
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            TransformEnemy?.Invoke();
            WhenFoodEaten();
        }
    }

}
