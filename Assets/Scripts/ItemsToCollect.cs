using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;

public class ItemsToCollect : MonoBehaviour {
	[SerializeField] private GameObject key;
	[SerializeField] private GameObject food;
	[SerializeField] private GameObject med;
	[SerializeField] private GameObject garageDoor;

	[SerializeField] private Text keyText;
	[SerializeField] private Text foodText;
	[SerializeField] private Text medKitText;

	private string keyStatus;
	private string foodStatus;
	private string medStatus;
	private int height = 3;


	//
	void Awake () {
		Assert.IsNotNull (key);
		Assert.IsNotNull (food);
		Assert.IsNotNull (med);
		Assert.IsNotNull (keyText);
		Assert.IsNotNull (foodText);
		Assert.IsNotNull (medKitText);
	}

	// 
	void Update () {
		if (GameManager.instance.HasKey == true) {
			keyStatus = "Yes";
		} else {
			keyStatus = "No";
		}

		if (GameManager.instance.HasFood == true) {
			foodStatus = "Yes";
		} else {
			foodStatus = "No";
		}

		if (GameManager.instance.HasMed == true) {
			medStatus = "Yes";
		} else {
			medStatus = "No";
		}

		keyText.text = "Key: " + keyStatus;
		foodText.text = "Food: " + foodStatus;
		medKitText.text = "Med Kit: " + medStatus;
	}

	public void PlayerHasKey () {
		if (!GameManager.instance.GameOver) {
			garageDoor.transform.position = new Vector3 (garageDoor.transform.position.x, garageDoor.transform.position.y + height, garageDoor.transform.position.z);
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
