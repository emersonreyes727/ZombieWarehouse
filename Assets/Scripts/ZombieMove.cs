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
	void FixedUpdate () {
		if (GameManager.instance.GameStart) {
			// game is running and zombie is alive, zombie moves to player 
			if (!GameManager.instance.GameOver && zombieHealth.IsAlive) {
				nav.SetDestination (player.transform.position);
			} 
			// game is running and zombie is dead
			if (!GameManager.instance.GameOver && !zombieHealth.IsAlive) {
				anim.Play ("die");
				nav.enabled = false;
				capCol.enabled = false;
				rb.isKinematic = true;
				rb.detectCollisions = false;
			} 
			// game is over and zombie is alive
			if (GameManager.instance.GameOver && zombieHealth.IsAlive) {
				nav.SetDestination (Vector3.zero);
			}
		}
	}
}
