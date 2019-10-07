using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public PlayerContoller player;
    
    public GameObject money;
    public GameObject playerInScene;
    public float totalBegTime;

    public GameObject boomer;

    public Transform[] spawnTargets;
    public Transform[] moveTargets;// Start is called before the first frame update

    public TextMeshPro[] angryTweets;
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        SpawnBoomers(); 

    }

    void SpawnBoomers()
    {

        for (int i = 0; i < 50; i++)
        {
            GameObject g = Instantiate(boomer, spawnTargets[Random.Range(0, spawnTargets.Length)]);
            g.GetComponent<Enemy>().player = playerInScene.GetComponent<PlayerContoller>();
            

            for (int j = 0; j < g.GetComponent<Enemy>().moveTarget.Length; j++)
            {
                g.GetComponent<Enemy>().moveTarget[j] = moveTargets[j];
            }

            for (int t = 0; t < g.GetComponent<Enemy>().tweet.Length; t++)
            {
                g.GetComponent<Enemy>().tweet[t] = angryTweets[t];
            }

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
