using UnityEngine;
using System.Collections;

public class SignBounce : MonoBehaviour {

	bool goUp = true;
	// Use this for initialization
	void Start () {
		StartCoroutine("Switch");
	}
	
	// Update is called once per frame
	void Update () {
		if (goUp) {
			transform.Translate(Vector2.up * 50 * Time.deltaTime);
		}

		else {
			transform.Translate(Vector2.down * 50 * Time.deltaTime);
		}
	}

	public void StartSwitch () {
		StartCoroutine("Switch");
		print("switching");
	}

	IEnumerator Switch () {
		while (true) {
			yield return new WaitForSeconds(0.5f);
			goUp = !goUp;
		}
	}
}
