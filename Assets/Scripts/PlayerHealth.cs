using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;

public class PlayerHealth : MonoBehaviour {
	[SerializeField] private Text life;

	private int health = 10;

	//
	void Awake () {
		Assert.IsNotNull (life);
	}
	
	// Update is called once per frame
	void Update () {
		life.text = "Life: " + health;

		if (health == 0) {
			Debug.Log ("player is dead");
			GameManager.instance.GameIsOver ();
		}
	}

	void OnTriggerEnter (Collider other) {
		health --;
		Debug.Log ("attack the player");
	}
}
