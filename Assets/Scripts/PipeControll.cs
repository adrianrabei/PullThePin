using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PipeControll : MonoBehaviour
{
    private GameObject[] total;
    private int count;
    private bool result;
    private int percentage;
    [SerializeField] private GameObject win;
    [SerializeField] private GameObject fail;
    [SerializeField] private Text text;
    void Start()
    {
        total = GameObject.FindGameObjectsWithTag("Colored");
        count = 0;
        result = false;
        percentage = 0;
    }

    void FixedUpdate()
    {
        SphereCounter();
        if(result)
        {
            Invoke("Result", 1);
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
            result = true;
        }
    }

    private void Result()
    {
        if(count < total.Length)
        {
            fail.SetActive(true);
            Time.timeScale = 0;
        }
        else win.SetActive(true);
        Time.timeScale = 0;
    }

}
