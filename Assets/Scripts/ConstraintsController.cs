﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstraintsController : MonoBehaviour
{
    private Rigidbody obj;
    private bool isBlowing;
    [SerializeField] private GameObject fail;

    void Start()
    {
        obj = GetComponent<Rigidbody>();
        isBlowing = false;
    }

    void FixedUpdate()
    {
        if(isBlowing)
        {
            Invoke("Unfreez", 0.4f);
            Invoke("Fail", 1.2f);
        }
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Bomb")
        {
            transform.gameObject.tag = "BlowOut";
            isBlowing = true;
            if(obj.isKinematic)
            {
                obj.isKinematic = false;
            }
        }
        if(other.gameObject.tag == "BlowOut")
        {
             transform.gameObject.tag = "BlowOut";
             isBlowing = true;
             if(obj.isKinematic)
            {
                obj.isKinematic = false;
            }
        }
        if(other.gameObject.tag == "Pipe")
        {
            Unfreez();
            Invoke("Freez", 2f);
        }
    }

    private void OnCollisionStay(Collision other) {
        if(other.gameObject.tag == "Bomb")
        {
            transform.gameObject.tag = "BlowOut";
            isBlowing = true;
        }
        if(other.gameObject.tag == "BlowOut")
        {
             transform.gameObject.tag = "BlowOut";
             isBlowing = true;
        }
        if(other.gameObject.tag == "Pipe")
        {
            Unfreez();
            Invoke("Freez", 2f);
        }
    }

    private void Unfreez()
    {
        obj.constraints = RigidbodyConstraints.None;
    }

    private void Freez()
    {
        obj.constraints = RigidbodyConstraints.FreezeAll;
    }

    private void Fail()
    {
        fail.SetActive(true);
        Time.timeScale = 0;
    }
}
