using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	int playerHealth = 10;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter (Collision collision) {
		
		if (collision.gameObject.tag == "zombie") {
			playerHealth --;

			Debug.Log (playerHealth);
			if (playerHealth == 0) {
				GameManager.instance.PlayerAttacked ();
			}
		}

	}
}
