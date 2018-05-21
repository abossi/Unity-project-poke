using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPokemon : MonoBehaviour {

	private Move move;
	public GameObject agro;
	public Attaque[] attaques = new Attaque[4];

	// Use this for initialization
	void Start () {
		move = GetComponent<Move>();
		attaques[0] = transform.GetChild(0).GetComponent<Attaque>();
	}
	
	// Update is called once per frame
	void Update () {
		Orientation();
	}

	void Orientation() {

		for (int i = 0 ; i < 4 ; i++) {
			if (attaques[i] && attaques[i].isRunning)
				return ;
		}

		if (agro) {
			Vector3 pz = agro.transform.position;
			pz.z = 0;
			float angle = Vector2.SignedAngle(Vector3.down, pz - transform.position);
			
			move.Orientation(angle);
			Move(angle, Vector3.Distance(pz, transform.position));
		}
	}

	void Move(float angle, float dist) {
		Vector3 vec = Vector3.zero;

		if (angle < -110 || angle > 110)
			vec.y += 1;
		else if (angle > -70 && angle < 70)
			vec.y -= 1;
		if (angle < 160 && angle > 20)
			vec.x += 1;
		else if (angle > -160 && angle < -20)
			vec.x -= 1;

		if (dist < 0.3f)
			vec = -vec;

		if (dist <= 0.3f && dist >= 0.2f) {
			move.Moving(Vector3.zero);
			attaques[0].Fire("");
		}
		else
			move.Moving(vec);
	}
}
