using UnityEngine;
using System.Collections;

public class StartScreenCharacterController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey("up")) {
			  transform.Translate(Vector2.up * Time.deltaTime * 60);
		}

		if (Input.GetKey("down")) {
			  transform.Translate(Vector2.down * Time.deltaTime * 60);
		}

		if (Input.GetKey("left")) {
			  transform.Translate(Vector2.left * Time.deltaTime * 60);
		}

		if (Input.GetKey("right")) {
			  transform.Translate(Vector2.right * Time.deltaTime * 60);
		}
	}
}
