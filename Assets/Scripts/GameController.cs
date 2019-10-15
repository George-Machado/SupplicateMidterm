using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public PlayerContoller player;
    
    public GameObject money;
    public GameObject playerInScene;
    public float totalBegTime;
    
    
    

    public GameObject boomer;

    public Transform[] spawnTargets;
    public Transform[] moveTargets;// Start is called before the first frame update
    public TextMeshProUGUI[] tweet;
    public TextMeshProUGUI gameOver; 
    
    void Start()
    {
       // Cursor.lockState = CursorLockMode.Locked;
       // Cursor.visible = false;
        SpawnBoomers(); 

    }
    void Update()
    {
        Winstate();
        
        FailState();
    }


    void SpawnBoomers()
    {
        List<Transform> usedSpawnTargets = new List<Transform>();



        for (int i = 0; i < 50; i++)
        {
            bool canSpawn = false;

            Transform spawnTarget = spawnTargets[Random.Range(0, spawnTargets.Length)];


            while (canSpawn == false)
            {
                if (usedSpawnTargets.Contains(spawnTarget))
                {
                    spawnTarget.position += new Vector3(Random.Range(-6,6),0, Random.Range(-6,6));
                }
                else
                {
                    canSpawn = true;
                }
                    
                
            }
            



            GameObject g = Instantiate(boomer, spawnTarget);
            g.GetComponent<Enemy>().player = playerInScene.GetComponent<PlayerContoller>();
            g.GetComponent<Enemy>().gameController = this;


            for (int j = 0; j < g.GetComponent<Enemy>().moveTarget.Length; j++)
            {
                g.GetComponent<Enemy>().moveTarget[j] = moveTargets[j];
            }
            
        }
    }



    void Winstate()
        {
            if (totalBegTime > 100f)
            {
                gameOver.text = "You win! press R to restart";

                if (Input.GetKey(KeyCode.R))
                {
                    SceneManager.LoadScene("StartScreen");
                }

                Debug.Log("win");
            }
        }

        void FailState()
        {
            if (player.emotionalEnergy <= 0f)
            {
                gameOver.text = "you lose!  press R to restart";
                if (Input.GetKey(KeyCode.R))
                {
                    SceneManager.LoadScene("StartScreen");
                }

                Debug.Log("Game over");
            }

        }

    }


