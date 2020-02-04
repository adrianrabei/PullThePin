using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinControll : MonoBehaviour
{
    private Rigidbody pin;
    private float speed = 25000f;
    private Collider coll;
    private float timeLeft = 1.3f;
    private bool destruction;
    void Start()
    {
        pin = GetComponent<Rigidbody>();
        coll = GetComponent<Collider>();
        destruction = false;
    }

    void FixedUpdate()
    {
       if(destruction){
            timeLeft -= Time.deltaTime;
            if(timeLeft < 1)
            {
                Destroy(this.gameObject);
            }
        }
    }

    private void OnMouseDown() {
        pin.AddForce(transform.right * speed);
        coll.enabled = false;
        destruction = true;
    }

    
}
