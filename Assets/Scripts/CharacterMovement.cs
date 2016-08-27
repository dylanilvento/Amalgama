using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {
	Rigidbody2D rb;
	bool grounded;
	bool facingRight = true;

	int moveSpeed = 125;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("up") && grounded) {
			print("up!");
			rb.velocity = new Vector2(rb.velocity.x, 400f);
			grounded = false;
		}

		if (Input.GetKey("right") && grounded) {
			//rb.velocity = Vector2.right * moveSpeed;
			rb.velocity = new Vector2(moveSpeed, rb.velocity.y);

			if (!facingRight) {
				gameObject.transform.localScale = new Vector2(gameObject.transform.localScale.x * -1f, gameObject.transform.localScale.y);
				facingRight = true;
			}
			
		}

		else if (Input.GetKey("left") && grounded) {
			//rb.velocity = Vector2.left * moveSpeed;
			rb.velocity = new Vector2(-1 * moveSpeed, rb.velocity.y);

			if (facingRight) {
				gameObject.transform.localScale = new Vector2(gameObject.transform.localScale.x * -1f, gameObject.transform.localScale.y);
				facingRight = false;
			}
			
		} 
	}

	void OnCollisionEnter2D (Collision2D other) {
		if (other.gameObject.layer == 9) {
			print("entered");
			grounded = true;
		}
	}

	// void OnCollisionExit2D (Collision2D other) {
	// 	if (other.gameObject.layer == 9) {
	// 		print("exited");
	// 		grounded = false;
	// 	}
	// }

}
