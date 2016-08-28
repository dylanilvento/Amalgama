using UnityEngine;
using System.Collections;

public class ImpCombat : MonoBehaviour {
	public GameObject[] damageNums = new GameObject[10];
	public GameObject deathExplosion;

	public GameObject element;

	int health = 10;

	ImpMovement movementScript;
	Rigidbody2D rb;
	SpriteRenderer sr;
	// Use this for initialization
	void Start () {
		movementScript = GetComponent<ImpMovement>();
		rb = GetComponent<Rigidbody2D>();
		sr = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.name.Equals("Sword Attack")) {
			if (other.gameObject.transform.parent.transform.position.x > gameObject.transform.position.x) TakeDamage(-1);
			else TakeDamage(1);
		}
	}

	void TakeDamage (int direction) {
		movementScript.StartStopWalkingCoroutine();
		rb.velocity = new Vector2(direction * 200f, 400f);

		int damage = Random.Range(0, 9);

		GameObject damageCounter = (GameObject) Instantiate(damageNums[damage], transform.position,  Quaternion.identity);
		damageCounter.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-150, 150f), Random.Range(150f, 250f));

		health -= damage;

		if (health <= 0) {
			Destroy(gameObject);

			int explosionNum = Random.Range(3, 6);

			for (int ii = 0; ii < explosionNum; ii++) {
				Instantiate(deathExplosion, new Vector2(transform.position.x - Random.Range(-30f, 30f), transform.position.y - Random.Range(-20f, 40f)),  Quaternion.identity);
			}

			int elementNum = Random.Range(1, 4);
			
			for (int ii = 0; ii < elementNum; ii++) {
				GameObject spawnedElement = (GameObject) Instantiate(element, transform.position,  Quaternion.identity);
				spawnedElement.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-150, 150f), Random.Range(150f, 250f));
			}
		}

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
