using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BegTime : MonoBehaviour
{

    public float begTime;

    public PlayerContoller player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (player.isKneeling())
        {
            begTime += 1f * Time.deltaTime;
        }
    }
}
