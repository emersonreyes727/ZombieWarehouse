using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	[SerializeField] private float force; // force of the projectile
	private bool projectileLaunched = false; // did the projectile fired

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (!projectileLaunched) {
			Rigidbody rb = GetComponent<Rigidbody> ();
			rb.AddForce (transform.forward, ForceMode.Impulse); // add force to projectile. Impule (one time)
			projectileLaunched = true; // so that this "if" statement will not run again
		}
	}
}
