using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public GameObject money;
    public GameObject playerInScene;
    public float totalBegTime;

    public GameObject boomer;

    public Transform[] spawnTargets;
    public Transform[] moveTargets;// Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        SpawnBoomers(); 

    }

    void SpawnBoomers()
    {

        for (int i = 0; i < 30; i++)
        {
            GameObject g = Instantiate(boomer, spawnTargets[Random.Range(0, spawnTargets.Length)]);
            g.GetComponent<Enemy>().player = playerInScene.GetComponent<PlayerContoller>();
            

            for (int j = 0; j < g.GetComponent<Enemy>().moveTarget.Length; j++)
            {
                g.GetComponent<Enemy>().moveTarget[j] = moveTargets[j];
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void WinState()
    {
        if (totalBegTime > 350f)
        {
            //Instantiate()
            
            Debug.Log("win");
        }
    }
    

}
