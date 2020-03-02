using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private GameObject bomb;
    private float power;
    private float radius;
    private float upForce;
    private Vector3 explosionPosition;
    private Collider[] colliders;
    private bool isDetonating;
    private bool canExplode;
    private bool gameOver;
    public GameObject otherBomb;
    private float t;
    [SerializeField] private GameObject explosioneffects;
    
    void Start()
    {
        power = 30;
        radius = 10;
        upForce = 1;
        isDetonating = false;
        canExplode = false;
        gameOver = false;
        t = 0.5f;
    }

    void FixedUpdate()
    {
        if(isDetonating)
        {
            Invoke("Detonating", t);
        }
    }

    private void Detonating()
    {
            explosionPosition = bomb.transform.position;
            colliders = Physics.OverlapSphere(explosionPosition, radius);

            foreach (Collider hit in colliders)
            {
                Rigidbody rb = hit.GetComponent<Rigidbody>();

                if(rb != null)
                {
                    rb.AddExplosionForce(power, explosionPosition, radius, upForce, ForceMode.Impulse);
                }
            }
            Instantiate(explosioneffects, explosionPosition, Quaternion.identity);
            Destroy(gameObject);
            bomb.SetActive(false);
    }
   
   private void OnCollisionEnter(Collision other) {
       if(other.gameObject.tag == "BlowOut" || other.gameObject.tag == "Pipe")
       {
            isDetonating = true;
            otherBomb.GetComponent<Explosion>().isDetonating = true;
            otherBomb.GetComponent<Explosion>().t += 1.15f;
            gameOver = true;
       }
       else if(other.gameObject.tag == "Bomb")
       {
            isDetonating = true;
            otherBomb.GetComponent<Explosion>().isDetonating = true;
            otherBomb.GetComponent<Explosion>().t += 1.15f;
       }
   }
}
