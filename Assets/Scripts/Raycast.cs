using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Raycast : MonoBehaviour {
	[SerializeField] private GameObject raycastIndicator;
	[SerializeField] private GameObject bullet;
	[SerializeField] private Transform bulletResetPosition;

	private int maxBullets = 10;
	private float distance = 20f;

	private GameObject player;
	private RaycastHit hit; 

	//
	void Awake () {
		Assert.IsNotNull (raycastIndicator);
		Assert.IsNotNull (bullet);
		Assert.IsNotNull (bulletResetPosition);
	}

	// Use this for initialization
	void Start () {
		player = GameManager.instance.Player;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (!GameManager.instance.GameOver) {
			Vector3 forward = transform.TransformDirection (Vector3.forward) * distance;
			Debug.DrawRay (transform.position, forward, Color.red);

			if (Physics.Raycast (transform.position, forward, out hit)) {
				if (hit.collider.gameObject.tag == "Floor") {
					raycastIndicator.SetActive (true);

					MoveRaycastIndicator ();

					if (Input.GetMouseButtonDown (0)) {
						Vector3 location = hit.point;
						DashMove (location);
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
			raycastIndicator.SetActive (false);
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
