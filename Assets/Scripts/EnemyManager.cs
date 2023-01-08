using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<GameObject> Enemy;
    public PacManManager pacManManger;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ManageEnemyMovement()
    {
        int delay = 0; 
        while (delay < 10)
        {
            if (delay > 8)
            {
                Enemy[0].GetComponent<EnemyMove>().enabled = true; 
            }

            else if (delay > 6)
            {
                Enemy[1].GetComponent<EnemyMove>().enabled = true;
            }

            else if (delay > 4)
            {
                Enemy[2].GetComponent<EnemyMove>().enabled = true;
            }

            else 
            {
                Enemy[3].GetComponent<EnemyMove>().enabled = true;
            }

            yield return new WaitForSeconds(5.0f); 
        }
    }

    public void EnemyToCage()
    {
        foreach (GameObject enemy in Enemy)
        {
            enemy.SetActive(true);
            EnemyMove enemyMove = enemy.GetComponent<EnemyMove>();
            if (enemyMove != null)
            {
                enemyMove.enabled = false; 
            }

            Enemy enemyScript = enemy.GetComponent<Enemy>(); 
            if (enemyScript != null)
            {
                enemyScript.EnemyPosReset(); 
            }
        }
        StartCoroutine(ManageEnemyMovement()); 
    }

}
