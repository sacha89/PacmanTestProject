using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PacManManager : MonoBehaviour
{
    public GameObject squares;

    public UIManager uiManager;

    public GameObject circles; 

     void OnEnable()
    {
        foreach(Transform square in squares.GetComponentInChildren<Transform>())
        {
            SquareFood squareScript = square.gameObject.GetComponent <SquareFood>();
            if (squareScript!=null)
            {
                squareScript.AddScore += ScoreManage; 

            }
        }

        foreach (Transform circle in circles.GetComponentInChildren<Transform>())
        {
            CircleFood circleScript = circle.gameObject.GetComponent<CircleFood>();
            if (circleScript != null)
            {
                circleScript.AddScore += ScoreManage;

            }
        }
    }

     void OnDisable()
    {
        foreach (Transform square in squares.GetComponentInChildren<Transform>())
        {
            SquareFood squareScript = square.gameObject.GetComponent<SquareFood>();
            if (squareScript != null)
            {
                squareScript.AddScore -= ScoreManage;

            }
        }

        foreach (Transform circle in circles.GetComponentInChildren<Transform>())
        {
            CircleFood circleScript = circle.gameObject.GetComponent<CircleFood>();
            if (circleScript != null)
            {
                circleScript.AddScore -= ScoreManage;

            }
        }
    }
    void ScoreManage (int increseValue)
    {
        GameState.gameScore += increseValue;
        uiManager.ScoreTextSet(GameState.gameScore);
    }

    void ManageEatenSquare ()
    {
        GameState.squareCount--;
        CheckEmptyMaze();
    }

    void CheckEmptyMaze()
    {
        if (GameState.squareCount == 0 && GameState.circleCount == 0)
        {
            NextLevel(); 
        }
    }

    void NextLevel()
    {
        SceneManager.LoadScene("EndScene");
    }
}
