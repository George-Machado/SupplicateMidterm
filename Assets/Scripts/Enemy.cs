using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using Random = UnityEngine.Random;


//USAGE: Put on Enemy
//INTENT: Controls movement
public class Enemy : MonoBehaviour
{
    public PlayerContoller player;

    public float speed;

    private bool _playerInRange;

    public Transform[] moveTarget;

    private Transform _currentTarget;

    public float minTime = 3;

    public float maxTime = 7;
    
    
    // Start is called before the first frame update
    void Start()
    {
        PickTarget();
    }

    // Update is called once per frame
    void Update()
    {
        if (_playerInRange && player.isKneeling())
        {
             FollowPlayer();
        }
        else
        {
            MoveToTarget();
        }
        
    }




    private void PickTarget()
    {
        float timeForNextChoice;
        
        _currentTarget = moveTarget[Random.Range (0, moveTarget.Length)];

        timeForNextChoice = Random.Range(minTime, maxTime);
        
        Invoke("PickTarget", timeForNextChoice);
    }

    private void MoveToTarget()
    {
        Ray ray = new Ray(transform.position, transform.forward);

        float rayDist = 2f;
        
        Debug.DrawRay(ray.origin, ray.direction * rayDist, Color.cyan);


        if (Physics.Raycast(ray, rayDist))
        {
            float turnChance = Random.Range(0f, 100f);

            if (turnChance > 50f)
            {
                transform.Rotate(0f,-90f,0f);
                
            }
            else 
            {
                transform.Rotate(0f,90f,0f);
            }
        }
        else
        {
            transform.LookAt(_currentTarget);

            transform.position += transform.forward * speed;
        }


       
        
        
    }
    
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _playerInRange = true;
            
        }
    }

    private void FollowPlayer()
    {
        
        
        transform.LookAt(player.transform);

        transform.position += transform.forward * speed;
        
    }

    private void OnTriggerExit(Collider other)
    {
        _playerInRange = false;
    }
}
