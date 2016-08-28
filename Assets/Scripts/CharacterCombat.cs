using UnityEngine;
using System.Collections;

public class CharacterCombat : MonoBehaviour {

	SpriteRenderer sr;
	Rigidbody2D rb;
	CharacterMovement charMove;
	public bool canTakeDamage = true;
	// Use this for initialization
	void Start () {
		sr = GetComponent<SpriteRenderer>();
		rb = GetComponent<Rigidbody2D>();
		charMove = GetComponent<CharacterMovement>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.layer == 10 && canTakeDamage) {
			TakeDamage();
		}
	}

	void OnCollisionEnter2D (Collision2D other) {
		if (other.gameObject.layer == 10 && canTakeDamage) {
			TakeDamage();
		}
	}

	void TakeDamage () {
		print(transform.localScale.x/Mathf.Abs(transform.localScale.x));
		rb.velocity = new Vector2((transform.localScale.x/Mathf.Abs(transform.localScale.x)) * -300f, 400f);
		charMove.StartJustLeftCoroutine();

		StartCoroutine("Flash");

	}

	IEnumerator Flash () {
		float t = 0.05f;

		while (t > 0f) {
			sr.color = Color.gray;

			yield return new WaitForSeconds(0.25f);

			sr.color = Color.white;

			yield return new WaitForSeconds(0.25f);

			t -= Time.deltaTime;
			print(t);
		}
	}
}
