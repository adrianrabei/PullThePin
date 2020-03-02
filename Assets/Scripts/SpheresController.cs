using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpheresController : GameManager
{
    private Rigidbody obj;
    private bool isBlowing;
    [SerializeField] private GameObject pipe;
    
    //public static int c;
    void Start()
    {
        obj = GetComponent<Rigidbody>();
        isBlowing = false;
    }

    void FixedUpdate()
    {
        if(isBlowing)
        {
            Invoke("Unfreez", 0.4f);
            Invoke("Fail", 1.2f);
        }
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Bomb")
        {
            transform.gameObject.tag = "BlowOut";
            isBlowing = true;
            if(obj.isKinematic)
            {
                obj.isKinematic = false;
            }
        }
        if(other.gameObject.tag == "BlowOut")
        {
            transform.gameObject.tag = "BlowOut";
            isBlowing = true;
            if(obj.isKinematic)
            {
                obj.isKinematic = false;
            }
        }
        if((other.gameObject.tag == "inPipe" || other.gameObject.tag == "Pipe") && gameObject.tag == "Colored")
        {
            InPipeCounting();
            Unfreez();
            Invoke("Freez", 2f);
        }
    }

    private void OnCollisionStay(Collision other) {
        if(other.gameObject.tag == "Bomb")
        {
            transform.gameObject.tag = "BlowOut";
            isBlowing = true;
        }
        if(other.gameObject.tag == "BlowOut")
        {
             transform.gameObject.tag = "BlowOut";
             isBlowing = true;
        }
        if((other.gameObject.tag == "inPipe" || other.gameObject.tag == "Pipe") && gameObject.tag == "Colored")
        {
           InPipeCounting();
           Unfreez();
        }
    }

    private void Unfreez()
    {
        obj.constraints = RigidbodyConstraints.None;
    }

    private void Freez()
    {
        obj.constraints = RigidbodyConstraints.FreezeAll;
    }

    public void InPipeCounting()
    {
        transform.gameObject.tag = "inPipe";
        pipe.GetComponent<PipeControll>().count++;
        pipe.GetComponent<PipeControll>().percentage = (pipe.GetComponent<PipeControll>().count * 100) / pipe.GetComponent<PipeControll>().totalSpheres;
        pipe.GetComponent<PipeControll>().text.text = pipe.GetComponent<PipeControll>().percentage + "%";
        pipe.GetComponent<PipeControll>().result = true;
    }
}
