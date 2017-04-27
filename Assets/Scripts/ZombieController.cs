using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.AI;

public class ZombieController : MonoBehaviour {

	[SerializeField] private Transform playerPosition;
	[SerializeField] private float range = 3.0f;
	[SerializeField] private AudioClip attackSfx;

	private Animator anim;
	private NavMeshAgent navMeshAgent;

	private AudioSource audio;

	void Awake () {
		Assert.IsNotNull (playerPosition);
	}

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		navMeshAgent = GetComponent<NavMeshAgent> ();
		audio = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance(transform.position, playerPosition.position) < range) {
			audio.PlayOneShot (attackSfx);
			anim.Play ("attack");

		} else {
			anim.Play ("walk");
			navMeshAgent.SetDestination (playerPosition.position);
		}
	}
}
