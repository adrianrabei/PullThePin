using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PipeControll : MonoBehaviour
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
    }

    void Update() {
         if(result)
        {
            StartCoroutine(Result());
            
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
            StartCoroutine(GameManager.Instance.Fail());
        }
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Bomb")
        {
            if(GameManager.Instance.canFail)
            {
                StartCoroutine(GameManager.Instance.Fail());
            }
        }
    }

    private IEnumerator Result()
    {
        yield return new WaitForSeconds(1);
        if(totalSpheres == inPipe)
        {
            if(count < totalSpheres)
            {
               StartCoroutine(GameManager.Instance.Fail());
            }
            else 
            {
                StartCoroutine(GameManager.Instance.Win());
            }
        }
    }
}
