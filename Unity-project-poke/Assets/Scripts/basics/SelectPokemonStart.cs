using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectPokemonStart : MonoBehaviour {

	public GameObject prefabPoke;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void StartKanto(GameObject prefab) {
		prefabPoke = prefab;
		DontDestroyOnLoad(gameObject);
		SceneManager.LoadScene("kanto");
	}
}
