using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ObjectToEat : MonoBehaviour
{
    public event Action <int> AddScore;
    protected int foodsScoreIncrementation;

    SpriteRenderer foodSpriteRender;
    BoxCollider2D foodBoxcollider;

    public TextMeshProUGUI scoreText;

    void OnEnable() 
    {
        foodSpriteRender = GetComponent<SpriteRenderer>();
        foodBoxcollider = GetComponent<BoxCollider2D>(); 

        if (foodSpriteRender!=null)
        {
            foodSpriteRender.enabled = true; 
        }

        if (foodBoxcollider != null)
        {
            foodBoxcollider.enabled = true;
        }
    }

    protected void WhenFoodEaten()
    {
        if (foodSpriteRender != null)
        {
            foodSpriteRender.enabled = false;
        }

        if (foodBoxcollider != null)
        {
            foodBoxcollider.enabled = false;
        }

        if (scoreText != null)
        {
            scoreText.gameObject.SetActive(true);
            scoreText.text = foodsScoreIncrementation.ToString();
        }

        StartCoroutine(DelayStartHiddenText());
        AddScore?.Invoke(foodsScoreIncrementation); 
    }

    IEnumerator DelayStartHiddenText()
    {
        int delay = 0; 
        while (delay < 1)
        {
            delay++;
            yield return new WaitForSeconds(1); 
        }

        if (scoreText != null)
        {
            scoreText.gameObject.SetActive(false);
        }
        
    }
}
