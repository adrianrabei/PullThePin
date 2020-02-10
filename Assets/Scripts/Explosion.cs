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
    [SerializeField] private GameObject explosioneffects;
    
    void Start()
    {
        power = 30;
        radius = 10;
        upForce = 1;
        isDetonating = false;
        canExplode = true;
        gameOver = false;
    }

    void FixedUpdate()
    {
        if(isDetonating)
        {
            Invoke("Detonating", 0.5f);
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
            Instantiate(explosioneffects, explosionPosition, transform.rotation);
            Destroy(gameObject);
            bomb.SetActive(false);
    }
   
   private void OnCollisionEnter(Collision other) {
       if(other.gameObject.tag == "BlowOut")
       {
            isDetonating = true;
            gameOver = true;
       }
       if(other.gameObject.tag == "Bomb")
       {
            isDetonating = true;
       }
   }
}
