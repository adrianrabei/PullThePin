using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    private Rigidbody sphere;
    [SerializeField] private Material matGreen;
    [SerializeField] private Material matRed;
    [SerializeField] private Material matBlue;
    [SerializeField] private Material matOrange;
    [SerializeField] private Material matPurple;
    [SerializeField] private Material matPink;
    [SerializeField] private Material matYellow;
    private Material color;

    private int colorNumber;

    private void Start() {
        sphere = GetComponent<Rigidbody>();
    }

    private void ColorPicker()
    {
        colorNumber = Random.Range(1, 7);

        switch(colorNumber)
        {
            case 1:
                color = matGreen;
                GetComponent<Renderer>().material = color;
                break;
            case 2:
                color = matOrange;
                GetComponent<Renderer>().material = color;
                break;
            case 3:
                color = matPink;
                GetComponent<Renderer>().material = color;
                break;
            case 4:
                color = matRed;
                GetComponent<Renderer>().material = color;
                break;
            case 5:
                color = matYellow;
                GetComponent<Renderer>().material = color;
                break;
            case 6:
                color = matPurple;
                GetComponent<Renderer>().material = color;
                break;
            case 7:
                color = matBlue;
                GetComponent<Renderer>().material = color;
                break;
            default:
                Debug.Log(colorNumber);
                break;
        }
    }

    private IEnumerator ChangeColor()
    {
        yield return new WaitForSeconds(0.16f);
        ColorPicker();
    }


    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Colored" && gameObject.tag == "Grey") {
            StartCoroutine(ChangeColor());
            transform.gameObject.tag = "Colored";
            
        }
    }

    private void OnCollisionStay(Collision other) {
        if(other.gameObject.tag == "Colored" && gameObject.tag == "Grey") {
            StartCoroutine(ChangeColor());
            transform.gameObject.tag = "Colored";
            
        }
    }
}
