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

    public float emotionalEnergy = 100f;

    public bool standing = true;

    private bool _enterTrigger;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        
    }

    private void Update()
    {
        Movement();

        if (_enterTrigger)
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
        if(Input.GetKeyDown(KeyCode.Space) && standing)
        {
            standingModel.SetActive(false);
            kneeling.SetActive(true);
            standing = false;
            Debug.Log("standing is flase");
        }
        else if (standing == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                standingModel.SetActive(true);
                kneeling.SetActive(false);
                standing = true;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("TwitterProfile"))
        {
            _enterTrigger = true;
            //Debug.Log("enter");
        }
    }

    public bool isKneeling()
    {
        return !standing;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("TwitterProfile"))
        {
            _enterTrigger = false;
            //Debug.Log("exit");
        }
    }
}
