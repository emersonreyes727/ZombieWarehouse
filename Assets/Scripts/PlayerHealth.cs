using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {
	[SerializeField] private Transform cube;

	private int health = 1;
	
	// Update is called once per frame
	void Update () {
		if (health == 0) {
			Debug.Log ("player is dead");
			GameManager.instance.GameIsOver ();
		}
	}

	void OnTriggerEnter (Collider other) {
			Debug.Log ("attack the player");
			cube.position = new Vector3 (0, 1, 0);

			health --;
	}
}
