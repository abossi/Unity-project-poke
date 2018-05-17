using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dresseur : MonoBehaviour {

	private Move move;
	public GameObject agro;
	public List<GameObject> pokemons;
	public GameObject pokemonActif;

	// Use this for initialization
	void Start () {
		move = GetComponent<Move>();
	}
	
	// Update is called once per frame
	void Update () {
		Orientation();
	}

	void Orientation() {
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

		if (dist < 1)
			vec = -vec;

		if (dist >= 1 && dist <= 1.5f)
			move.Moving(Vector3.zero);
		else
			move.Moving(vec);

		if (!pokemonActif && pokemons.Count != 0 && dist <= 1.5f) {
			SendPoke(vec);
		}
		else if (pokemons.Count == 0 && !pokemonActif) {
			Destroy(gameObject);
			return ;
		}
	}

	void SendPoke(Vector3 vec) {
		pokemonActif = Instantiate(pokemons[0], transform.position + vec * 0.5f, Quaternion.Euler(0, 0, 0));
		pokemons.RemoveAt(0);
		pokemonActif.GetComponent<AIPokemon>().agro = agro;
	}
}
