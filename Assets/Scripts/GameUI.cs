using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour {
	[SerializeField] private GameObject startUI;

	private Vector3 newPosition = new Vector3 (0, 0, -9);

	public void StartGame () {
		startUI.SetActive (false);
		transform.position = newPosition;

		GameManager.instance.GameHasStarted ();
	}
}
