using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class GameManager : MonoBehaviour {
	[SerializeField] private GameObject player;

	public static GameManager instance = null;

	//
	private bool gameOver = false;
	private bool gameStart = false;
	private bool hasKey = false;
	private bool hasFood = false;
	private bool hasMed = false;

	//
	public GameObject Player {
		get { return player; }
	}

	public bool GameOver {
		get { return gameOver; }
	}

	public bool GameStart {
		get { return gameStart; }
	}

	public bool HasKey {
		get { return hasKey; }
	}

	public bool HasFood {
		get { return hasFood; }
	}

	public bool HasMed {
		get { return hasMed; }
	}

	//
	void Awake () {
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}

		DontDestroyOnLoad (gameObject);

		Assert.IsNotNull (player);
	}

	//
	public void GameIsOver () {
		gameOver = true;
	}

	public void GameHasStarted () {
		gameStart = true;
	}

	public void PlayerHasKey () {
		hasKey = true;
	}

	public void PlayerHasFood () {
		hasFood = true;
	}

	public void PlayerHasMed () {
		hasMed = true;
	}
}
