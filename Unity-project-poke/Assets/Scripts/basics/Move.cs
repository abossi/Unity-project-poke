using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

	private Animator animator;
	private CircleCollider2D collide;
	private statistics stat;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		collide = GetComponent<CircleCollider2D>();
		stat = GetComponent<statistics>();
		animator.speed = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Orientation(float angle) {

		animator.SetBool("bot", false);
		animator.SetBool("top", false);
		animator.SetBool("left", false);
		animator.SetBool("right", false);

		if (angle >= -45 && angle < 45)
			animator.SetBool("bot", true);
		else if (angle >= 45 && angle < 135)
			animator.SetBool("right", true);
		else if (angle >= -135 && angle < -45)
			animator.SetBool("left", true);
		else
			animator.SetBool("top", true);
	}

	public void Moving(Vector3 vec) {
		if (vec.x != 0 && vec.y != 0)
			vec /= 1.414f;
		
		if (vec.x != 0 || vec.y != 0)
			animator.speed = 1;
		else
			animator.speed = 0;

		vec *= ((float)stat.vitesse + 100f) / 200.0f;

		transform.Translate(vec * Time.deltaTime);
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

	public Vector3 Center() {
		return transform.position + new Vector3(collide.offset.x, collide.offset.y, 0);
	}

	public float Radius() {
		return collide.radius;
	}
}
