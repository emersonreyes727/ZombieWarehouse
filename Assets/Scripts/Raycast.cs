using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Raycast : MonoBehaviour {
	[SerializeField] private GameObject raycastIndicator;

	private float distance = 10f;
	private float teleportDistance = 4f;
	private float menuSpace = 1f;

	private GameObject player;
	private RaycastHit hit; 

	//
	void Awake () {
		Assert.IsNotNull (raycastIndicator);
	}

	// Use this for initialization
	void Start () {
		player = GameManager.instance.Player;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		// if the game is NOT over
		if (!GameManager.instance.GameOver) {
			Vector3 forward = transform.TransformDirection (Vector3.forward) * distance;
			Debug.DrawRay (transform.position, forward, Color.red);

			if (Physics.Raycast (transform.position, forward, out hit)) {
				if (hit.collider.gameObject.tag == "Floor") {
					// disable the raycast so that the menu can be placed in front of the player
					if (Vector3.Distance (player.transform.position, hit.point) <= menuSpace) {
						raycastIndicator.SetActive (false); // turn off raycast
					// enable the raycast
					} else if (Vector3.Distance (player.transform.position, hit.point) > menuSpace && Vector3.Distance (player.transform.position, hit.point) < teleportDistance) {
						raycastIndicator.SetActive (true);

						MoveRaycastIndicator ();

						if (Input.GetMouseButtonDown (0)) {
							Vector3 location = hit.point;
							DashMove (location);
						}
					// so that player can't teleport over a long distance
					} else if (Vector3.Distance (player.transform.position, hit.point) >= teleportDistance) {
						raycastIndicator.SetActive (false); // turn off raycast
					}
				} // turns of raycast when it hits the zombie
				if (hit.collider.gameObject.tag == "Zombie") {
					raycastIndicator.SetActive (false);
				}
			}
		} else {
			raycastIndicator.SetActive (false); // turn off raycast if game is over
		}
	}

	private void MoveRaycastIndicator () {
		raycastIndicator.transform.position = hit.point;
	}

	// moves the player smoothly 
	private void DashMove(Vector3 location) {
		iTween.MoveTo (player, 
			iTween.Hash (
				"position", new Vector3 (location.x, location.y, location.z), 
				"time", .5F, 
				"easetype", "linear"
			)
		);
	}
}
