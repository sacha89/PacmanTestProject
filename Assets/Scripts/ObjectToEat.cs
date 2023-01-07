using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ObjectToEat : MonoBehaviour
{
    public event Action <int> AddScore;
    protected int foodsScore;

    public TextMeshProUGUI scoreText;

    private SpriteRenderer foodSpriteRender;
    private BoxCollider2D foodBoxcollider;

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
            scoreText.text = foodsScore.ToString();
        }

        StartCoroutine(DelayStartHiddenText());
        AddScore?.Invoke(foodsScore); 
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
