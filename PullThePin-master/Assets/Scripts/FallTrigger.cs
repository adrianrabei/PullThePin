using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallTrigger : GameManager
{
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Colored" || other.gameObject.tag == "Grey")
        {
            Invoke("Fail", 1);
        }
    }
}
