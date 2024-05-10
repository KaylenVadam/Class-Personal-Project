using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;

    public EnemySpawner enemySpawner;
    public GameObject spawnManager;
    
    public int maxHealth = 100;
    int currentHealth;
    public bool isDead;
    
    

    // Start is called before the first frame update
    public void connectToGameObject(GameObject room)
    {
        spawnManager = room;
        enemySpawner = spawnManager.GetComponent<EnemySpawner>();
    }



    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        //play hurt animation
        //animator.SetTrigger("Hurt");

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    

    void Die()
    {
        Debug.Log("Enemy died!");
        //die animation
        //animator.SetBool("isDead, true");

        //disable the enemy
        //turn off enemy ai and gravity
        enemySpawner.countDown();
        Invoke("destroyGameObject", .1f);
    }

    void destroyGameObject()
    {
        Destroy(gameObject);
    }
}
