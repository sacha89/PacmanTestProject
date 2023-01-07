using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class UIManager : MonoBehaviour
{

    public TextMeshProUGUI scoreText; 

    public void ScoreTextSet (int score)
    {
        scoreText.text = score.ToString();
            
    }
}
