using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.UI;


//USAGE: Put on Enemy
//INTENT: Controls movement
public class Enemy : MonoBehaviour
{
    public PlayerContoller player;
    public GameController gameController;
    public float speed;

    private bool _playerInRange;

    public Transform[] moveTarget;

    private Transform _currentTarget;

    public float minTime = 3;

    public float maxTime = 7;
    
    public string[] tweets;
    
    
    // Start is called before the first frame update
    void Start()
    {
        PickTarget();
    }

    // Update is called once per frame
    void Update()
    {
       transform.position = new Vector3(transform.position.x,4f,transform.position.z);
       
       transform.eulerAngles = new Vector3(0,transform.eulerAngles.y,0f);
       
       
        
        if (_playerInRange && player.IsKneeling())
        {
             FollowPlayer();
        }
        else 
        {
            MoveToTarget();
        }
        
        Tweet();
    }




    private void PickTarget()
    {
        float timeForNextChoice;
        
        _currentTarget = moveTarget[Random.Range (0, moveTarget.Length)];

        timeForNextChoice = Random.Range(minTime, maxTime);
        
        Invoke("PickTarget", timeForNextChoice);
        
        transform.LookAt(_currentTarget);
    }

    private void MoveToTarget()
    {
        Ray ray = new Ray(transform.position, transform.forward);

        float rayDist = 7f;
        
        Debug.DrawRay(ray.origin, ray.direction * rayDist, Color.cyan);


        if (Physics.Raycast(ray, rayDist))
        {
            float turnChance = Random.Range(0f, 100f);

            if (turnChance > 50f)
            {
                transform.Rotate(0f,-90f,0f);
                 
               // transform.position += transform.forward * speed;
            }
            else 
            {
                transform.Rotate(0f,90f,0f);
                //transform.position += transform.forward * speed;
            }
        }
        else
        {
            
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

    
        
        if (Vector3.Distance(transform.position, player.transform.position) > 15f)
        {
            transform.position += transform.forward * speed;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        _playerInRange = false;
    }

    void Tweet()
    {
        
        if (_playerInRange && player.IsKneeling())
        {
            StartCoroutine("Tweets");
        }
        else if (_playerInRange==false && player.standing)
        {
            StopCoroutine("Tweets");
        }
    }

    IEnumerator Tweets()
    {
        for (int i = 0; i < gameController.tweet.Length; i++) 
        {
            gameController.tweet[i].text = tweets[i];
            yield return new WaitForSeconds(1);
        }
    }
}
