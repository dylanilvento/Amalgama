using UnityEngine;
using System.Collections;

public class ElementalBallMovement : MonoBehaviour {
	bool moveLeft = true;
	int direction = 1;
	public float lifetime = 8f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector2.left * direction * Time.deltaTime * 150);
		lifetime -= Time.deltaTime;

		if (lifetime <- 0f) {
			Destroy(gameObject);
		}
	}

	public void SetDirection(bool val) {
		moveLeft = val;

		if (!moveLeft) {
			direction = -1;
			gameObject.transform.localScale = new Vector2 (gameObject.transform.localScale.x * -1, gameObject.transform.localScale.y);
		}

	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.layer == 8) {
			Destroy(gameObject);
		}
	}
}
