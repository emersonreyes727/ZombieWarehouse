using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	private int force = 10;
	private Vector3 resetPosition = new Vector3 (0, -5, 0);
	private int distance = 20;

	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}

	void Update () {
		// if the bullet is far away from the resetposition
		// just let the bullet fly away
		// don't let the gameobjects to stop the bullet
		if (Vector3.Distance (transform.position, resetPosition) > distance) {
			transform.position = resetPosition;
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		// the force applied to the bullet
		rb.AddForce (transform.forward * force, ForceMode.Impulse);
	}
}
