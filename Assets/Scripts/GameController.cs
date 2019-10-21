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
    private bool _hasWon= false;
    
    void Start()
    {
       // Cursor.lockState = CursorLockMode.Locked;
       // Cursor.visible = false;
        SpawnBoomers(); 

    }
    void Update()
    {
        if (_hasWon == false)
        {
            Winstate();
        }

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
                    spawnTarget.position += new Vector3(Random.Range(-3,6),0, Random.Range(-3,3));
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
        Debug.Log(totalBegTime);
        if (totalBegTime >= 60f)
        {
            gameOver.text = "You win! press R to restart";

            if (Input.GetKey(KeyCode.R))
            {
                SceneManager.LoadScene("StartScreen");
            }

            Debug.Log("win");

            _hasWon = true;
            SpawnMoney();
        }

    }

    private void SpawnMoney()
    {
        float playerX = playerInScene.transform.position.x;
        float playerY = playerInScene.transform.position.y + 30f;
        float playerZ = playerInScene.transform.position.z;


        for (int i = 0; i < 100; i++)
        {
            Instantiate(money, new Vector3(playerX, playerY, playerZ), playerInScene.transform.rotation);
            
        }
        
    }

    void FailState()
        {
            if (player.energyBar.fillAmount <= 0f)
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


