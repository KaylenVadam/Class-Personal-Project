using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    
    public GameObject Enemy1;
    public GameObject Boss;
    public Enemy enemycode;
    public Enemy enemycode2;
    public Enemy enemycode3;
    public float count = 0f;
    public float bossCount = 0f;
    public GameObject self;
    public GameObject enemyJustSpawned;
    public GameObject enemyJustSpawned2;
    public GameObject enemyJustSpawned3;

   // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            SpawnEnemies();
        }

        if(other.CompareTag("Enemy"))
        {
            count ++;

        }

        if(other.CompareTag("Boss"))
        {
            bossCount = 2;

        }

        
    }


    public void countDown()
    {
        count --;
    }

    public void bossCountDown()
    {
        bossCount --;
    }

    void SpawnEnemies()
    {
       
            enemyJustSpawned = GameObject.Instantiate(Enemy1, transform.position, transform.rotation);
            enemyJustSpawned2 = GameObject.Instantiate(Enemy1, transform.position, transform.rotation);
            enemyJustSpawned3 = GameObject.Instantiate(Enemy1, transform.position, transform.rotation);
            enemycode = enemyJustSpawned.GetComponent<Enemy>();
             enemycode2 = enemyJustSpawned2.GetComponent<Enemy>();
              enemycode3 = enemyJustSpawned3.GetComponent<Enemy>();
            enemycode.connectToGameObject(self);
            enemycode2.connectToGameObject(self);
            enemycode3.connectToGameObject(self);

            Debug.Log("room 1");
       
    }
}
