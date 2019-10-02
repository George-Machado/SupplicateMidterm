using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public BegTime[] begTimes;

    private float _totalBegTime; 
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

    public void TotalBegTime()
    {
        for (int i = 0; i < begTimes.Length ; i++)
        {
            
        }

    }

}
