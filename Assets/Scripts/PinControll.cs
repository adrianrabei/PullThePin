using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinControll : MonoBehaviour
{
    private GameObject pin;
    private Transform startPosx;
    private Transform finishPosx;
    [SerializeField] private GameObject start;

    [SerializeField] private GameObject finish;
    private float t;
    private bool clicked;

    void Start()
    {
        startPosx = start.transform;
        finishPosx = finish.transform;
        t = 0.01f;
    }

    void FixedUpdate()
    {
        if(clicked)
        {
            transform.position = Vector3.Lerp(startPosx.position, finishPosx.position, t);
            t += 0.05f;
        }
    }

    private void OnMouseDown() {
        clicked = true;
    }    
}
