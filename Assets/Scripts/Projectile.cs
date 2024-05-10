using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject self;

    // Start is called before the first frame update
    void Start()
    {
        DestroyProjectile();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DestroyProjectile()
    {
        Destroy(self, 5);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Destroy(self);
            Debug.Log("hit");
        }
        ;
    }
}
