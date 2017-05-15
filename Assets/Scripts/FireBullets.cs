using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;

public class FireBullets : MonoBehaviour {
	// the bullet clone goes to this empty parent gameobject
	[SerializeField] private Transform bulletResetPosition;
	[SerializeField] private GameObject bullet;
	[SerializeField] private Text bulletsText;
	[SerializeField] private AudioClip soundFx;

	private GvrAudioSource gunFire;

	private int maxBullets = 500;

	// 
	void Awake () {
		Assert.IsNotNull (bullet);
		Assert.IsNotNull (bulletResetPosition);
		Assert.IsNotNull (bulletsText);
	}

	// Use this for initialization
	void Start () {
		gunFire = GetComponent<GvrAudioSource> ();
	}

	void Update () {
		bulletsText.text = "Bullets: " + maxBullets;
	}
	
	// instead of using raycast in fixedupdate (it fires twice), use "event trigger" pointer click
	// to fire the bullets one time only. Tried putting FireProjectiel in its own script w/ the gamemanager
	// but didn't work. I move it to the main camera and it works.
	public void FireProjectile () {
		if (maxBullets > 0) {
			Instantiate (bullet, transform.position, transform.rotation, bulletResetPosition);
			gunFire.PlayOneShot (soundFx);
			maxBullets--;
			Debug.Log ("Fire!!!");
		}
	}
}
