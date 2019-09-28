using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       


    }

    private void OnTriggerEnter(Collider other)
    {
        transform.LookAt(player);

        transform.position += transform.forward * speed;
    }
}
