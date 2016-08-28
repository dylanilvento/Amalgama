using UnityEngine;
using System.Collections;

public class CameraFollowPlayer : MonoBehaviour {

	public Transform target;
	Vector3 relPos, endPos;
	float maxSpeed = 5f;

	// public bool followPlayer;

	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {
		if (target.position.y > transform.position.y) {
			transform.Translate(Vector2.up * Time.deltaTime * 100);
		}

		else if (target.position.y < transform.position.y - 108) {
			transform.Translate(Vector2.down * Time.deltaTime * 300);
		}

		transform.position = new Vector3(target.transform.position.x, transform.position.y, transform.position.z);// - relPos;

	}
}
