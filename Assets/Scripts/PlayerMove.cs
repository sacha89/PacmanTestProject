using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public GameObject pacManPlayer;
    public Animator pacManPlayerAnim;

    private float dir = 0;
    Vector3 initialPos; 
    public bool IsMoving; 


    // Start is called before the first frame update
    void Start()
    {
        initialPos = transform.position; 
        PacmanPlayerReset();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsMoving)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                pacManPlayer.transform.rotation = Quaternion.Euler(0, 0, 0);
                dir = 0; 
           }

            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                pacManPlayerAnim.transform.rotation = Quaternion.Euler(0, 0, 180);
                dir = 180;
            }

            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                pacManPlayer.transform.rotation = Quaternion.Euler(0, 0, 90);
                dir = 90;
            }

            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                pacManPlayer.transform.rotation = Quaternion.Euler(0, 0, -90);
                dir = -90; 
            }


            if (dir == 0)
            {
                transform.position += new Vector3(1 * Time.deltaTime, 0, 0); 
            }

            else if (dir == 180f)
            {
                transform.position += new Vector3(-1 * Time.deltaTime, 0, 0);
            }

            else if (dir == 90f)
            {
                transform.position += new Vector3(0, 1 * Time.deltaTime, 0);
            }

            else if (dir == -90) {

                transform.position += new Vector3(0, -1 * Time.deltaTime, 0);
            }
        }
    }

        public void continuousPlayAnimation ()
            {
               pacManPlayerAnim.enabled = true; 
            }   

        IEnumerator StartGameWaiting ()
    {
        IsMoving = false;
        int delay = 0; 
        while (delay < 1)
        {
            delay++;
            yield return new WaitForSeconds(2); 
        }


        IsMoving = true; 
    }

     public void PacmanPlayerReset()
    {
        pacManPlayer.transform.rotation = Quaternion.Euler(0, 0, 0);
        dir = 0;
        pacManPlayer.transform.position = initialPos;
        StartCoroutine(StartGameWaiting()); 
    }

    }
