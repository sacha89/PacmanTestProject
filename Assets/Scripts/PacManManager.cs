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


    public List<GameObject> Enemies; 

     void OnEnable()
    {

        StartCoroutine(ManageEnemyMove()); 
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

        foreach (GameObject enemy in Enemies)
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

        foreach (GameObject enemy in Enemies)
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
        NextLevel();
    }

    IEnumerator ManageEnemyMove()
    {
        int delay = 0;
        while (delay < 12)
        {
            if (delay > 10)
            {
                Enemies[0].GetComponent<EnemyMove>().enabled = true;
            }

            else if (delay > 8)
            {
                Enemies[1].GetComponent<EnemyMove>().enabled = true;
            }

            else if (delay > 6)
            {
                Enemies[2].GetComponent<EnemyMove>().enabled = true;
            }

            else
            {
                Enemies[3].GetComponent<EnemyMove>().enabled = true;
            }

            yield return new WaitForSeconds(2.0f);
        }
    }

     void ManagePlayerEnemyCollision ()
    {
        playerAnim.SetBool("death", true);
        playerMove.IsMoving = false; 
        foreach (GameObject enemy in Enemies)
        {
            enemy.SetActive(false); 
        }

        StartCoroutine(ManagePlayerAfterDeath()); 
    }
    
    void EnemyToBox()
    {
        foreach (GameObject enemy in Enemies)
        {
            enemy.SetActive(true);
            EnemyMove enemyMoveScript = enemy.GetComponent<EnemyMove>(); 
            if (enemyMoveScript != null)
            {
                enemyMoveScript.enabled = false; 
            }

            Enemy enemyScript = enemy.GetComponent<Enemy>(); 
            if (enemyScript != null)
            {
                enemyScript.EnemyPosReset();
            }
        }

        StartCoroutine(ManageEnemyMove());
    }
}
