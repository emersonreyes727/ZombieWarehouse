using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.AI;

public class ZombieController : MonoBehaviour {

	[SerializeField] private Transform playerPosition;
	[SerializeField] private float range = 3.0f;

	private Animator anim;
	private NavMeshAgent navMeshAgent;

	private int zombieHealth = 3;

	void Awake () {
		Assert.IsNotNull (playerPosition);
	}

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		navMeshAgent = GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance(transform.position, playerPosition.position) < range) {
			anim.Play ("attack");
		} else {
			anim.Play ("walk");
			navMeshAgent.SetDestination (playerPosition.position);
		}
	}



	void OnTriggerEnter(Collider Projectile) {
		//Destroy(other.gameObject);
		zombieHealth --;
		Debug.Log (zombieHealth);
	}
}
