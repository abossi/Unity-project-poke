using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectPokemonStart : MonoBehaviour {

	public GameObject prefabPoke;
	public GameObject prefabPokeParent;
	public int pokemonType;

	public List<GameObject> listPrefabPoke = new List<GameObject>();
	public List<GameObject> listPrefabPokeParent = new List<GameObject>();

	public List<Button> listButton;
	public List<Text> listText;
	public List<int> coinsToUnlock;

	// Use this for initialization
	void Start () {
		for (int i = 0 ; i < listPrefabPoke.Count ; i++) {
			listText[i].text = PlayerPrefs.GetInt(listPrefabPoke[i].name + "Coin").ToString();
			if (PlayerPrefs.GetInt(listPrefabPoke[i].name + "Available") == 0) {
				if (PlayerPrefs.GetInt(listPrefabPoke[i].name + "Coin") >= coinsToUnlock[i])
					PlayerPrefs.SetInt(listPrefabPoke[i].name + "Available", 1);
				else {
					listButton[i].interactable = false;
					listText[i].text = PlayerPrefs.GetInt(listPrefabPoke[i].name + "Coin").ToString() + " / " + coinsToUnlock[i];
				}
			}
		}
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
