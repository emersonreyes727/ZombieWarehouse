using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieMove : MonoBehaviour {
	private NavMeshAgent nav;
	private Animator anim;
	private CapsuleCollider capCol;
	private Rigidbody rb;
	private GameObject player;
	private ZombieHealth zombieHealth;

	// Use this for initialization
	void Start () {
		nav = GetComponent<NavMeshAgent> ();
		anim = GetComponent<Animator> ();
		capCol = GetComponent<CapsuleCollider> ();
		rb = GetComponent<Rigidbody> ();
		player = GameManager.instance.Player;
		zombieHealth = GetComponent<ZombieHealth> ();
	}
	
	// Update is called once per frame
	void Update () {
		// game is running and zombie is alive, zombie moves to player 
		if (!GameManager.instance.GameOver && zombieHealth.IsAlive) {
			nav.SetDestination (player.transform.position);
		// game is running and zombie is dead
		} else if (!GameManager.instance.GameOver && !zombieHealth.IsAlive) {
			anim.Play ("die");
			nav.enabled = false;
			capCol.enabled = false;
			rb.isKinematic = false;
		// game is over and zombie is alive
		} else if (GameManager.instance.GameOver && zombieHealth.IsAlive) {
			nav.SetDestination (Vector3.zero);
		// game is over and zombie is dead
		} else {
			nav.enabled = false;
			capCol.enabled = false;
			rb.isKinematic = false;
		}
	}
}
