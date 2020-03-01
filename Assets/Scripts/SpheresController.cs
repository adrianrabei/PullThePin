using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpheresController : MonoBehaviour
{
    private Rigidbody obj;
    private bool isBlowing;
    [SerializeField] private PipeControll pipe;
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
            GameManager.Instance.Fail();
        }
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Bomb")
        {
            print("Ebobo");
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
           Unfreez();
           InPipeCounting();
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
        pipe.count++;
        pipe.percentage = (pipe.count * 100) / pipe.totalSpheres;
        pipe.text.text = pipe.percentage + "%";
        pipe.result = true;
    }
}
