using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    //public Animator animator;

    public Transform attackPoint;
    public LayerMask enemyLayers;
    
    public float attackRange = 0.5f;
    public int attackDamageBasic = 40;
    public int attackDamageHeavy = 100;

    public bool heavyReady = false;
    public float attackRate = 2f;
    float nextAttackTime = 0f;

     public AudioSource audioSource;

    // Update is called once per frame
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            heavyReady = true;
        }
        if(Input.GetKeyUp(KeyCode.LeftControl))
        {
            heavyReady = false;
        }

        if(Time.time >= nextAttackTime)
        {
            if(heavyReady == false && Input.GetKeyDown(KeyCode.Mouse0))
            {
                AttackBasic();
                nextAttackTime = Time.time + 1f / attackRate;
            }       

            if(heavyReady == true && Input.GetKeyDown(KeyCode.Mouse0))
            {
                AttackHeavy();
                nextAttackTime = Time.time + 1f / attackRate;
            }       
        }
    }


    void AttackBasic()
    {
        //play animation
        // animator.SetTrigger("Attack");

        //decect enemies in range
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);
        //damage them
        foreach(Collider enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamageBasic);
        }
        Debug.Log("basic");
        audioSource.Play();
    }

    void AttackHeavy()
    {
        //play animation
        // animator.SetTrigger("Attack");

        //decect enemies in range
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);
        //damage them
        foreach(Collider enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamageHeavy);
        }
        Debug.Log("Heavy");
        audioSource.Play();
    }
    void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
        return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}


