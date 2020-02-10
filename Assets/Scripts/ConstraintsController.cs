﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstraintsController : MonoBehaviour
{
    private Rigidbody obj;
    private bool isBlowing;
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
    }

    private void Unfreez()
    {
        obj.constraints = RigidbodyConstraints.None;
    }
}