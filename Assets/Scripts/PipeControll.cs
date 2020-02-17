using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PipeControll : GameManager
{
    private Rigidbody pipe;
    private GameObject[] total;
    private int count;
    private bool result;
    private int percentage;
    [SerializeField] private Text text;
    private int inPipe;
    private bool isAll;
    void Start()
    {
        pipe = GetComponent<Rigidbody>();
        count = 0;
        result = false;
        percentage = 0;
        inPipe = 0;
        isAll = false;
    }

    void FixedUpdate()
    {
        SphereCounter();
        Debug.Log("Total colored:" + total.Length);
        Debug.Log("Now in pipe:" + inPipe);
        if(result)
        {
            Invoke("Result", 2);
        }
    }

    private void SphereCounter()
    {
        total = GameObject.FindGameObjectsWithTag("Colored");
       
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Grey")
        {
            Destroy(other.gameObject);
            result = true;
        }
        if(other.gameObject.tag == "Colored")
        {
            count++;
            percentage = (count * 100) / total.Length;
            text.text = percentage + "%";
            inPipe++;
            result = true;
        }
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Bomb")
        {
            pipe.constraints = RigidbodyConstraints.None;
            Invoke("Fail", 1);
        }
    }

    private void Result()
    {
        if(inPipe == total.Length)
        {
            if(count < total.Length)
            {
                Invoke("Fail", 1);
            }
            else 
            {
                Invoke("Win", 1);
                
            }
        }
    }

}
