using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SpaceShipMove : MonoBehaviour
{
    private Rigidbody _rb;

    private Vector3 _inputVector;

    public float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        bool thrust = Input.GetKey(KeyCode.Space);

        _inputVector.y = horizontal;
        _inputVector.x = vertical;

        if (thrust)
        {
            _inputVector.z = 1f;
        }
        else
        {
            _inputVector.z = 0f;
        }
        
        
    }

    private void FixedUpdate()
    {
        _rb.AddRelativeTorque(_inputVector.x,_inputVector.y,0f);
        
        _rb.AddRelativeForce(0f,0f,_inputVector.z * speed);
    }
}
