using UnityEngine;
using System.Collections;

public class ForgeCollider : MonoBehaviour {
	public GameObject sign;
	SpriteRenderer[] signChildren;
	// Use this for initialization
	void Start () {
		//sign.SetActive(false);
		signChildren = sign.GetComponentsInChildren<SpriteRenderer>();
		foreach (SpriteRenderer item in signChildren) {
			item.color = Color.clear;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.layer == 8) {
			//sign.SetActive(true);
			//sign.GetComponent<SignBounce>().StartSwitch();

			sign.GetComponent<SpriteRenderer>().color = Color.white;

			foreach (SpriteRenderer item in signChildren) {
				item.color = Color.white;
			}
		}
	}

	void OnTriggerExit2D (Collider2D other) {
		if (other.gameObject.layer == 8) {
			sign.GetComponent<SpriteRenderer>().color = Color.clear;

			foreach (SpriteRenderer item in signChildren) {
				item.color = Color.clear;
			}
		}
	}
}
