using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class ItemsToCollect : MonoBehaviour {
	[SerializeField] private GameObject key;
	[SerializeField] private GameObject food;
	[SerializeField] private GameObject med;

	void Awake () {
		Assert.IsNotNull (key);
		Assert.IsNotNull (food);
		Assert.IsNotNull (med);
	}

	public void PlayerHasKey () {
		if (!GameManager.instance.GameOver) {
			key.SetActive (false);
			GameManager.instance.PlayerHasKey ();
		} else {
			key.SetActive (true);
		}
	}

	public void PlayerHasFood () {
		if (!GameManager.instance.GameOver) {
			food.SetActive (false);
			GameManager.instance.PlayerHasFood ();
		} else {
			food.SetActive (true);
		}
	}

	public void PlayerHasMed () {
		if (!GameManager.instance.GameOver) {
			med.SetActive (false);
			GameManager.instance.PlayerHasMed ();
		} else {
			med.SetActive (true);
		}
	}
}
