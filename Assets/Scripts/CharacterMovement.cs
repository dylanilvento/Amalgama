using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {
	Rigidbody2D rb;
	bool grounded;
	bool facingRight = true;
	bool canAttack = true;
	bool justLeft = false;

	public BoxCollider2D swordAttack;

	Animator anim;
	int moveSpeed = 125;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}	

	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("up") && grounded) {
			print("up!");
			rb.velocity = new Vector2(rb.velocity.x, 400f);
			grounded = false;

			StartCoroutine("FlashJustLeft");

		}

		if (Input.GetKeyDown("space") && canAttack) {
			anim.SetTrigger("attack");
			StartCoroutine("FlashAttack");
		}

		if (Input.GetKey("right")) {
			//rb.velocity = Vector2.right * moveSpeed;
			if (grounded) rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
			else if (!justLeft && !facingRight) rb.velocity = new Vector2(moveSpeed / 4, rb.velocity.y);
			anim.SetBool("walk", true);
			if (!facingRight) {
				gameObject.transform.localScale = new Vector2(gameObject.transform.localScale.x * -1f, gameObject.transform.localScale.y);
				facingRight = true;
			}
			
		}

		else if (Input.GetKey("left")) {
			//rb.velocity = Vector2.left * moveSpeed;
			if (grounded) rb.velocity = new Vector2(-1 * moveSpeed, rb.velocity.y);
			else if (!justLeft && facingRight) rb.velocity = new Vector2(-1 * moveSpeed / 4, rb.velocity.y);

			anim.SetBool("walk", true);
			if (facingRight) {
				gameObject.transform.localScale = new Vector2(gameObject.transform.localScale.x * -1f, gameObject.transform.localScale.y);
				facingRight = false;
			}
			
		}

		else if (Input.GetKeyUp("left") || Input.GetKeyUp("right")) {
			anim.SetBool("walk", false);
		}
	}

	void OnCollisionEnter2D (Collision2D other) {
		if (other.gameObject.layer == 9) {
			// print("entered");
			grounded = true;
		}
	}

	IEnumerator FlashAttack () {
		canAttack = false;
		swordAttack.enabled = true;

		yield return new WaitForSeconds(0.3f);

		swordAttack.enabled = false;
		canAttack = true;
	}

	IEnumerator FlashJustLeft () {
		justLeft = true;

		print(justLeft);
		yield return new WaitForSeconds(0.25f);

		justLeft = false;
	}


}
