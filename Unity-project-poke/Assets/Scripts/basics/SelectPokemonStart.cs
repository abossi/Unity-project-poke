using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectPokemonStart : MonoBehaviour {

	public GameObject prefabPoke;
	public GameObject prefabPokeParent;
	public int pokemonType;

	public List<GameObject> listPrefabPoke = new List<GameObject>();
	public List<GameObject> listPrefabPokeParent = new List<GameObject>();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void StartKanto(int prefabNum) {
		prefabPoke = listPrefabPoke[prefabNum];
		prefabPokeParent = listPrefabPokeParent[prefabNum];
		pokemonType = prefabNum;
		
		DontDestroyOnLoad(gameObject);
		SceneManager.LoadScene("kanto");
	}
}
