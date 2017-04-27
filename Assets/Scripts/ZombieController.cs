using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.AI;

public class ZombieController : MonoBehaviour {

	[SerializeField] private Transform playerPosition;
	[SerializeField] private float range = 3.0f;
	[SerializeField] private float timeBetweenAttacks = 1.0f;

	private Animator anim;
	private NavMeshAgent navMeshAgent;
	private bool playerInRange;

	void Awake () {
		Assert.IsNotNull (playerPosition);
	}

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		navMeshAgent = GetComponent<NavMeshAgent> ();

		StartCoroutine (attack());
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance(transform.position, playerPosition.position) < range) {
			playerInRange = true;
		} else {
			playerInRange = false;

			anim.Play ("walk");
			navMeshAgent.SetDestination (playerPosition.position);
		}
	}

	IEnumerator attack () {
		if (playerInRange && !GameManager.instance.GameOver) {
			anim.Play ("attack");
			yield return new WaitForSeconds (timeBetweenAttacks);
		}
		yield return null;
		StartCoroutine (attack());
	}
}
