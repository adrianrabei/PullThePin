using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PipeControll : GameManager
{
    private Rigidbody pipe;
    public GameObject[] total;
    public int count;
    public bool result;
    public int percentage;
    [SerializeField] public Text text;
    public int inPipe;
    public int totalSpheres;
    void Start()
    {
        pipe = GetComponent<Rigidbody>();
        count = 0;
        result = false;
        percentage = 0;
        inPipe = 0;
        totalSpheres = ColoredCounter() + GreyCounter();

    }

    void FixedUpdate()
    {
        inPipe = InPipeCounter();

        if(result)
        {
            Invoke("Result", 1);
        }
    }

    

    private int ColoredCounter()
    {
        total = GameObject.FindGameObjectsWithTag("Colored");
        return total.Length;
    }

    private int InPipeCounter()
    {
        total = GameObject.FindGameObjectsWithTag("inPipe");
        return total.Length;
    }

    private int GreyCounter()
    {
        total = GameObject.FindGameObjectsWithTag("Grey");
        return total.Length;
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Grey")
        {
            Destroy(other.gameObject);
            Invoke("Fail", 2);
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
        if(totalSpheres == inPipe)
        {
            if(count < totalSpheres)
            {
                Invoke("Fail", 0.5f);
            }
            else 
            {
                Invoke("Win", 0.5f);
                NextScene();
            }
        }
    }

}
