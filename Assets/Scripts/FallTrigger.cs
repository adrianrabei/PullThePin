using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Colored" || other.gameObject.tag == "Grey")
        {
           StartCoroutine(GameManager.Instance.Fail());
        }
    }
}
