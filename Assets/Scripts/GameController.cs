using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public GameObject money;

    public float totalBegTime; 
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

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
