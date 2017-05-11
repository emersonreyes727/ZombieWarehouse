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
		// set to "less than equals" to 0, NOT "equal" to 0
		// sometimes when ontriggerenter is called it subtracts more than 1
		// so the health ends up becoming a negative number
		if (health <= 0) {
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
