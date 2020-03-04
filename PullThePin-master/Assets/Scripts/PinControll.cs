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
        t = 0.001f;
    }

    void FixedUpdate()
    {
        if(clicked)
        {
            transform.position = Vector3.Lerp(startPosx.position, finishPosx.position, t);
            t += 0.005f;
            Invoke("PinDestroy", 0.2f);
        }
    }

    private void OnMouseDown() {
        clicked = true;
    } 

    private void PinDestroy()
    {
        Destroy(gameObject);
    }   
}
