using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;


//USAGE: put this on your player
//INTENT: move player using physics
public class PlayerContoller : MonoBehaviour
{

    private Rigidbody _rb;

    private Vector3 _pInput;

    public float speed;
    
    public GameObject kneeling;

    public GameObject standingModel;

    private bool _standing = true;

    private bool _enterTrigger;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        
    }

    private void Update()
    {
        Movement();

        if (_enterTrigger);
        {
            ModelChange();
        }
    }

    private void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");


        _pInput = horizontal * transform.right;
        _pInput += vertical * transform.forward;
    }

    private void FixedUpdate()
    {

        _rb.velocity = _pInput * speed;
        
    }
    
    private void ModelChange()
    {
        
        
        
        
        if(Input.GetKeyDown(KeyCode.Space) && _standing)
        {
            standingModel.SetActive(false);
            kneeling.SetActive(true);
            _standing = false;
        }
        else if (_standing == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                standingModel.SetActive(true);
                kneeling.SetActive(false);
                _standing = true;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        _enterTrigger = true;
        Debug.Log("enter");

    }

    private void OnTriggerExit(Collider other)
    {
        _enterTrigger = false;
        Debug.Log("exit");
    }
}
