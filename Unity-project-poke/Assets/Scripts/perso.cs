using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class perso : MonoBehaviour {

	private Move move;
	public Attaque[] attaques = new Attaque[4];

	// Use this for initialization
	void Start () {
		move = GetComponent<Move>();
	}
	
	// Update is called once per frame
	void Update () {
		Orientation();
		Move();
		if (Input.GetKeyDown("space"))
			attaques[0].Fire();
	}

	void Orientation() {
		Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		pz.z = 0;
		float angle = Vector2.SignedAngle(Vector3.down, pz - transform.position);
		
		move.Orientation(angle);
	}

	void Move() {
		Vector3 vec = Vector3.zero;

		if (Input.GetKey("w"))
			vec.y += 1;
		if (Input.GetKey("s"))
			vec.y -= 1;
		if (Input.GetKey("d"))
			vec.x += 1;
		if (Input.GetKey("a"))
			vec.x -= 1;

		move.Moving(vec);
	}

	void OnTriggerEnter2D(Collider2D other)
    {
    	Dresseur dresseur = other.gameObject.GetComponent<Dresseur>();
        if (dresseur)
        	dresseur.agro = gameObject;
    }
}
