using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Raycast : MonoBehaviour {
	[SerializeField] private GameObject raycastIndicator;
	[SerializeField] private GameObject bullet;
	[SerializeField] private Transform bulletResetPosition;
	[SerializeField] private CapsuleCollider capCol;

	private int maxBullets = 10;
	private float distance = 10f;

	private GameObject player;
	private RaycastHit hit; 

	//
	void Awake () {
		Assert.IsNotNull (raycastIndicator);
		Assert.IsNotNull (bullet);
		Assert.IsNotNull (bulletResetPosition);
		Assert.IsNotNull (capCol);
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
					// so that player can't teleport over a long distance
					if (Vector3.Distance (player.transform.position, hit.point) < 3) {
						raycastIndicator.SetActive (true);

						MoveRaycastIndicator ();

						if (Input.GetMouseButtonDown (0)) {
							Vector3 location = hit.point;
							DashMove (location);
						}

					} else {
						raycastIndicator.SetActive (false); // turn off raycast
					}
				}
				if (hit.collider.gameObject.tag == "Zombie") {
					raycastIndicator.SetActive (false);

					if (maxBullets > 0) {
						FireProjectile ();
					}
				}
			}
		} else {
			raycastIndicator.SetActive (false); // turn off raycast if game is over
		}
	}

	private void MoveRaycastIndicator () {
		raycastIndicator.transform.position = hit.point;
	}

	private void FireProjectile () {
		if (Input.GetMouseButtonDown (0)) {
			Instantiate (bullet, transform.position, transform.rotation, bulletResetPosition);
			maxBullets--;
			Debug.Log ("Fire!!!");
		}
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
