using UnityEngine;
using System.Collections;

public class StartScreenSpawnTriggers : MonoBehaviour {
	public GameObject elementText;
	SpriteRenderer textSR;
	bool collided;
	// Use this for initialization
	void Start () {
		textSR = elementText.GetComponent<SpriteRenderer>();
		textSR.color = Color.clear;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.layer == 8) {
			print("works");
			collided = true;
			StartCoroutine("BlinkText");
			
		}
	}

	void OnTriggerExit2D (Collider2D other) {
		if (other.gameObject.layer == 8) {
			// print("works");
			collided = false;
			// StartCoroutine("BlinkText");
			
		}
	}

	IEnumerator BlinkText () {
		while (collided) {
			textSR.color = Color.white;
			yield return new WaitForSeconds(0.5f);	
			textSR.color = Color.clear;
			yield return new WaitForSeconds(0.5f);	
		}
		
	}
	

}
