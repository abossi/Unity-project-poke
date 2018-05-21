using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dresseur : MonoBehaviour {

	private Move move;
	public GameObject agro;
	public List<statistics> pokemons;
	private int pokemonCount = 0;

	// Use this for initialization
	void Start () {
		move = GetComponent<Move>();
	}
	
	// Update is called once per frame
	void Update () {
		Orientation();
	}

	public void Orientation() {
		if (agro && agro.GetComponent<perso>().justDead) {
			agro = null;
			pokemonCount = 0;
			for (int i = 0 ; i < pokemons.Count ; i++) {
				pokemons[i].PVActu = pokemons[i].PV;
				pokemons[i].transform.SetParent(transform);
				pokemons[pokemonCount].transform.position += Vector3.zero;
				pokemons[i].transform.gameObject.SetActive(false);
				pokemons[i].GetComponent<AIPokemon>().agro = null;
			}
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

		if (dist < 1)
			vec = -vec;

		if (dist >= 0.8 && dist <= 1.1f)
			move.Moving(Vector3.zero);
		else
			move.Moving(vec);

		if ((pokemonCount == 0 || pokemons[pokemonCount - 1].PVActu == 0) && pokemons.Count != pokemonCount && dist <= 1.1f) {
			SendPoke((dist < 1) ? -vec : vec);
		}
		else if (pokemons.Count == pokemonCount && pokemonCount != 0 && pokemons[pokemonCount - 1].PVActu == 0) {
			for (int i = 0 ; i < pokemons.Count ; i++)
				pokemons[i].transform.SetParent(transform);
			Destroy(gameObject);
			return ;
		}
	}

	void SendPoke(Vector3 vec) {
		if (pokemonCount != 0) {
			pokemons[pokemonCount - 1].transform.gameObject.SetActive(false);
		}
		pokemons[pokemonCount].transform.position += vec * 0.2f;
		pokemons[pokemonCount].transform.gameObject.SetActive(true);
		pokemons[pokemonCount].GetComponent<AIPokemon>().agro = agro;
		pokemons[pokemonCount].transform.SetParent(null);
		pokemonCount++;
	}
}
