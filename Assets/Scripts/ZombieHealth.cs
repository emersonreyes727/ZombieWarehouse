using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHealth : MonoBehaviour {
	private int health = 1;
	private bool isAlive = true;

	public bool IsAlive {
		get { return isAlive; }
	}
	
	// Update is called once per frame
	void Update () {
		if (health == 0) {
			Debug.Log ("zombie dead!!!");
			isAlive = false;
		}	
	}

	void OnTriggerEnter (Collider other) {
		if (other.tag == "Bullet") {
			Debug.Log ("hit the zombie!!!");
			health --;
		}
	}
}
