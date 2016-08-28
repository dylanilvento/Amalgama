using UnityEngine;
using System.Collections;

public class StopExplosion : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine("EndExplosion");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator EndExplosion () {
		yield return new WaitForSeconds(0.75f);
		Destroy(gameObject);
	}
}
