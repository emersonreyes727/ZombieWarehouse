using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class FireBullets : MonoBehaviour {
	// the bullet clone goes to this empty parent gameobject
	[SerializeField] private Transform bulletResetPosition;
	[SerializeField] private GameObject bullet;

	private int maxBullets = 5;

	// 
	void Awake () {
		Assert.IsNotNull (bullet);
		Assert.IsNotNull (bulletResetPosition);
	}
	
	// instead of using raycast in fixedupdate (it fires twice), use "event trigger" pointer click
	// to fire the bullets one time only. Tried putting FireProjectiel in its own script w/ the gamemanager
	// but didn't work. I move it to the main camera and it works.
	public void FireProjectile () {
		if (maxBullets > 0) {
			Instantiate (bullet, transform.position, transform.rotation, bulletResetPosition);
			maxBullets--;
			Debug.Log ("Fire!!!");
		}
	}
}
