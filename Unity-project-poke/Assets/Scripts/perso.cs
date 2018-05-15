using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class perso : MonoBehaviour {

	private Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		Orientation();
		Move();
	}

	void Orientation() {
		Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		pz.z = 0;

		animator.SetBool("bot", false);
		animator.SetBool("top", false);
		animator.SetBool("left", false);
		animator.SetBool("right", false);
		float angle = Vector2.SignedAngle(Vector3.down, pz - transform.position);
		if (angle >= -45 && angle < 45)
			animator.SetBool("bot", true);
		else if (angle >= 45 && angle < 135)
			animator.SetBool("right", true);
		else if (angle >= -135 && angle < -45)
			animator.SetBool("left", true);
		else
			animator.SetBool("top", true);
	}

	void Move() {
		Vector3 move = Vector3.zero;

		if (Input.GetKey("w"))
			move.y += 1;
		if (Input.GetKey("s"))
			move.y -= 1;
		if (Input.GetKey("d"))
			move.x += 1;
		if (Input.GetKey("a"))
			move.x -= 1;

		if (move.x != 0 && move.y != 0)
			move /= 1.414f;
		
		if (move.x != 0 || move.y != 0)
			animator.speed = 1;
		else
			animator.speed = 0;

		transform.Translate(move * Time.deltaTime);
	}

	public Vector3 GetDir() {
		if (animator.GetBool("bot"))
			return Vector3.down;
		if (animator.GetBool("top"))
			return Vector3.up;
		if (animator.GetBool("left"))
			return Vector3.left;
		return Vector3.right;
	}
}
