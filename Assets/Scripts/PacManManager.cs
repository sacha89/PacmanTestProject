using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PacManManager : MonoBehaviour
{
    public GameObject squares;

    public UIManager uiManager;

    public GameObject circles;

    public Animator playerAnim;

    public PlayerMove playerMove;
    public EnemyManager enemyManager;

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

        foreach (GameObject enemy in enemyManager.Enemy)
        {
            Enemy enemyScript = enemy.GetComponent<Enemy>();
            if (enemyScript != null)
            {
                enemyScript.CollidingWithPlayer += ManagePlayerEnemyCollision;
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

        foreach (GameObject enemy in enemyManager.Enemy)
        {
            Enemy enemyScript = enemy.GetComponent<Enemy>();
            if (enemyScript != null)
            {
                enemyScript.CollidingWithPlayer -= ManagePlayerEnemyCollision;
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

    IEnumerator ManagePlayerAfterDeath()
    {
        int delay = 0; 
        while (delay < 2)
        {
            delay++;
            yield return new WaitForSeconds(1);
        }

        Debug.Log("GameOver");
        playerAnim.SetBool("death", false); 
    }

    public void ManagePlayerEnemyCollision ()
    {
        playerAnim.SetBool("death", true);
        playerMove.IsMoving = false; 
        foreach (GameObject enemy in enemyManager.Enemy)
        {
            enemy.SetActive(false); 
        }

        StartCoroutine(ManagePlayerAfterDeath()); 
    }
}
