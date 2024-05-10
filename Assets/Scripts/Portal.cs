using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
  [SerializeField] Transform destination;
  [SerializeField] Transform destination2;
  [SerializeField] Transform destination3;
  [SerializeField] Transform finaldestination;
  public int roomNumber;
  public bool teleported;

  public EnemySpawner enemySpawner;
  public LevelCounter levelCounter;
  public playerHealth PlayerHealth;
  
  

  void Start()
    {
		
    }

  void OnDrawGizmos()
  {
	  Gizmos.color = Color.white;
	  Gizmos.DrawWireSphere(destination.position, .4f);
	  var direction = destination.TransformDirection(Vector3.forward);
	  Gizmos.DrawRay(destination.position, direction);

	  Gizmos.color = Color.white;
	  Gizmos.DrawWireSphere(destination2.position, .4f);
	  var direction2 = destination2.TransformDirection(Vector3.forward);
	  Gizmos.DrawRay(destination2.position, direction2);
  }

  public void increaseLevelCounter()
  {
	  levelCounter.counter();
  }

  void OnTriggerEnter(Collider other)
  {
	  roomNumber = Random.Range(1,4);
	  PlayerHealth.Heal();

	  if(levelCounter.numberOfTeleports == 8)
	  {
		  Debug.Log("meeting");
		  if(other.CompareTag("Player") && other.TryGetComponent<ThirdPersonMovement>(out var player) && enemySpawner.count <= 0f)
		  {
			player.Teleport(finaldestination.position);
		  }
		  
	  }
	  else if(levelCounter.numberOfTeleports <= 8)
	  {
		  Debug.Log("under");
		  if(other.CompareTag("Player") && other.TryGetComponent<ThirdPersonMovement>(out var player) && enemySpawner.count <= 0f)
			{
		  
				if(roomNumber == 1)
				{
					player.Teleport(destination.position);
				}
				if(roomNumber == 2)
				{
					player.Teleport(destination2.position);
				}
				if(roomNumber == 3)
				{
					player.Teleport(destination2.position);
				}
				

				levelCounter.counter();
				Invoke("reset", .1f);
			}
			

	  }
	  

	  

  }

  void reset()
  {
	  teleported = false;
  }
}
