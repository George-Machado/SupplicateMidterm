using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


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

    public float maxEmotionalEnergy = 100f;

    public bool standing = true;

    private bool _enterTrigger;

    public bool boomerInRange;

    public Image energyBar;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();

    }

    private void Update()
    {

        if (standing)
        {
            Movement();
            if (IsKneeling())
            {
                _rb.velocity = _pInput;
            }
        }
        
        if (_enterTrigger)
        {
            ModelChange();
        }
        
        if (boomerInRange == false)
        {
            emotionalEnergy += 1f * Time.deltaTime;
            
            energyBar.fillAmount = emotionalEnergy/maxEmotionalEnergy;
            
            if (emotionalEnergy > maxEmotionalEnergy)
            {
                emotionalEnergy = maxEmotionalEnergy;
            }
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

        if (other.gameObject.CompareTag("Boomer") && IsKneeling())
        {
            boomerInRange = true;
            emotionalEnergy -= 1f * Time.deltaTime;
            if (emotionalEnergy < 0)
            {
                emotionalEnergy = 0;
            }
            energyBar.fillAmount = emotionalEnergy/maxEmotionalEnergy;
            
        }
        
    }

    public bool IsKneeling()
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
        
        if (other.gameObject.CompareTag("Boomer") && standing)
        {
            boomerInRange = false;

        }
    }
}
