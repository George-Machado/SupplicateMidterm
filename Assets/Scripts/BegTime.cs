using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BegTime : MonoBehaviour
{

    public float begTime;

    private GameController _GM;
    public PlayerContoller player;
    // Start is called before the first frame update
    void Start()
    {
      _GM =  GameObject.Find("GamaGOD").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (player.IsKneeling())
        {
            begTime += 1f * Time.deltaTime;

            _GM.totalBegTime += 1f * Time.deltaTime;


        }
    }
}
