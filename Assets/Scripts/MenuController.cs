using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {
	bool paused = false;
	SpriteRenderer[] menuItems;
	// Use this for initialization
	void Start () {
		menuItems = gameObject.GetComponentsInChildren<SpriteRenderer>();
		TurnOffMenu();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("escape") && !paused) {
			TurnOnMenu();
			Time.timeScale = 0;
			paused = true;
		}
		else if (Input.GetKeyDown("escape") && paused) {
			TurnOffMenu();
			paused = false;
			Time.timeScale = 1;
		}


	}

	void TurnOffMenu () {

		foreach (SpriteRenderer item in menuItems) {
			item.color = Color.clear;
		}
	}

	void TurnOnMenu () {

		foreach (SpriteRenderer item in menuItems) {
			item.color = Color.white;
		}
	}

}
