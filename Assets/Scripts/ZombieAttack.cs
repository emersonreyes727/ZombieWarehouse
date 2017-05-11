using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttack : MonoBehaviour {
	private int distance = 2;

	private Animator anim;
	private GameObject player;
	private ZombieHealth zombieHealth;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		player = GameManager.instance.Player;
		zombieHealth = GetComponent<ZombieHealth> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!GameManager.instance.GameOver && zombieHealth.IsAlive) {
			// if zombie gets too close it will attack
			if (Vector3.Distance (transform.position, player.transform.position) < distance) {
				anim.Play ("attack");
			}
		}
	}
}
