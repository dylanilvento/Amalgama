﻿using UnityEngine;
using System.Collections;

public class ImpMovement : MonoBehaviour {
	public float moveTime;
	float moveTimeRemaining;

	bool canWalk = true;

	int direction = -1;
	public int moveSpeed = 100;

	Animator anim;
	Rigidbody2D rb;
	// Use this for initialization
	void Start () {
		moveTimeRemaining = moveTime;
		anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if (canWalk) {
			if (moveTimeRemaining > 0f) {
				anim.SetBool("walk", true);
				rb.velocity = new Vector2(moveSpeed * direction, rb.velocity.y);
				moveTimeRemaining -= Time.deltaTime;
			}

			else if (moveTimeRemaining <= 0f) {
				gameObject.transform.localScale = new Vector2(gameObject.transform.localScale.x * -1f, gameObject.transform.localScale.y);
				moveTimeRemaining = moveTime;
				direction *= -1;
			}
		}	
	}

	public int GetDirection () {
		return direction;
	}

	public void StartStopWalkingCoroutine () {
		StartCoroutine("StopMovement");
	}

	IEnumerator StopMovement () {
		canWalk = false;

		yield return new WaitForSeconds(1f);

		canWalk = true;
	}
}
