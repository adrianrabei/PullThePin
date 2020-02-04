using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] private Material matGreen;

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Colored") {
            GetComponent<Renderer>().material = matGreen;
            transform.gameObject.tag = "Colored";
        }
    }
}
