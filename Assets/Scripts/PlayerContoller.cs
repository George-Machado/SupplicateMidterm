using System;
using System.Collections;
using System.Collections.Generic;
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

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        
    }

    private void Update()
    {
        Movement();
        ModelChange();
    }

    private void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");


        _pInput = horizontal * transform.right;
        _pInput += vertical * transform.forward;
    }

    private void ModelChange()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            standingModel.SetActive(false);
        }
    }

    private void FixedUpdate()
    {

        _rb.velocity = _pInput * speed;
        
    }
}
