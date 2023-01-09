using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 

public class SquareFood : ObjectToEat
{

    public event Action SquareFoodDisparition; 

    // Start is called before the first frame update
    void Start()
    {
        foodsScoreIncrementation = 1; 
    }

     void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SquareFoodDisparition?.Invoke();
            WhenFoodEaten();
           
        }
    }
}
