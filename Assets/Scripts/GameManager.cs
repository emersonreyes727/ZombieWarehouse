using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;

	[SerializeField] private GameObject player;

	private bool gameOver = false;

	// getters
	public GameObject Player {
		get { return player; }	
	}

	public bool GameOver {
		get { return gameOver; }
	}

	// run before void Start ()
	void Awake () {
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}

		DontDestroyOnLoad (gameObject);

		Assert.IsNotNull (player);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// this will run when the player is hit.
	// it will pass the currentHp (health point)
	/*public void PlayerHit (int currentHp) {
		if (currentHp > 0) {
			gameOver = false;
		} else {
			gameOver = true;
		}
	} 
	*/
}
