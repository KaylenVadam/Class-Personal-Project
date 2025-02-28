﻿
using UnityEngine;
using UnityEngine.AI;

public class EnemyAiTutorial : MonoBehaviour
{
    public NavMeshAgent agent;

    public AudioSource audioSource;

    
    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public Transform attackPoint;
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject projectile;
    public int attackDamage = 20;
    public float attackSphereSize = 2f;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    public void start()
    {
         audioSource = GetComponent<AudioSource>();
    }

    private void Awake()
    {
        player = GameObject.Find("ThirdPersonPlayer").transform;
        agent = GetComponent<NavMeshAgent>();
        audioSource = GetComponent<AudioSource>();

        
        attackPoint = gameObject.transform.Find("attackpoint skelly");
    }

    private void Update()
    {
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInAttackRange && playerInSightRange) AttackPlayer();

        audioSource.Play();
    }

    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }
    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        
        //Make sure enemy doesn't move
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            ///ranged Attack code here
            //Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            //rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            //rb.AddForce(transform.up * 8f, ForceMode.Impulse);
            ///End of ranged attack code

            //decect player in range
        Collider[] hitPlayers = Physics.OverlapSphere(attackPoint.position, attackSphereSize, whatIsPlayer);
        //damage them
        foreach(Collider Player in hitPlayers)
        {
            Player.GetComponent<playerHealth>().TakeDamage(attackDamage);
        }
        Debug.Log("enemy attack");

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);

        if(attackPoint == null)
        return;
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(attackPoint.position, attackSphereSize);
    }
}
