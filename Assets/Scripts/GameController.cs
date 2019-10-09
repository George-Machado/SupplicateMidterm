using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

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
    
    
    void Start()
    {
       // Cursor.lockState = CursorLockMode.Locked;
       // Cursor.visible = false;
        SpawnBoomers(); 

    }

    void SpawnBoomers()
    {

        for (int i = 0; i < 50; i++)
        {
            GameObject g = Instantiate(boomer, spawnTargets[Random.Range(0, spawnTargets.Length)]);
            g.GetComponent<Enemy>().player = playerInScene.GetComponent<PlayerContoller>();
            g.GetComponent<Enemy>().gameController = this;


            for (int j = 0; j < g.GetComponent<Enemy>().moveTarget.Length; j++)
            {
                g.GetComponent<Enemy>().moveTarget[j] = moveTargets[j];
            }
            
        }

        // Update is called once per frame
        void Update()
        {
            WinState();

            FailState();
        }

        void WinState()
        {
            if (totalBegTime > 350f)
            {
                //Instantiate()

                Debug.Log("win");
            }
        }

        void FailState()
        {
            if (player.emotionalEnergy <= 0f)
            {
                Debug.Log("Game over");
            }

        }

    }

}
