using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsPanel : MonoBehaviour {

	public Button IVAttaqueUp;
	public Button IVDefenseUp;
	public Button IVAttSpeUp;
	public Button IVDefSpeUp;
	public Button IVPVUp;
	public Button IVVitesseUp;

	public Button EVAttaqueDown;
	public Button EVAttaqueUp;
	public Button EVDefenseDown;
	public Button EVDefenseUp;
	public Button EVAttSpeDown;
	public Button EVAttSpeUp;
	public Button EVDefSpeDown;
	public Button EVDefSpeUp;
	public Button EVPVDown;
	public Button EVPVUp;
	public Button EVVitesseDown;
	public Button EVVitesseUp;

	public Text IVAttaqueVal;
	public Text IVDefenseVal;
	public Text IVAttSpeVal;
	public Text IVDefSpeVal;
	public Text IVPVVal;
	public Text IVVitesseVal;

	public Text EVAttaqueVal;
	public Text EVDefenseVal;
	public Text EVAttSpeVal;
	public Text EVDefSpeVal;
	public Text EVPVVal;
	public Text EVVitesseVal;

	public Text CoinsName;
	public Text CoinsVal;

	public perso pers;

	private statistics stats;

	public int old_coin_val = 5;

	// Use this for initialization
	void Start () {
		stats = pers.transform.gameObject.GetComponent<statistics>();
		CoinsName.text = pers.pokemonType + " Coin :";
		old_coin_val = PlayerPrefs.GetInt(pers.pokemonType + "Coin");
		CoinsVal.text = old_coin_val.ToString();
		RefreshVal();
		RefreshButtons();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void RefreshVal() {
		stats.attaqueIV = PlayerPrefs.GetInt(pers.pokemonType + "AttaqueIV");
		IVAttaqueVal.text = stats.attaqueIV.ToString();
		stats.defenseIV = PlayerPrefs.GetInt(pers.pokemonType + "DefenseIV");
		IVDefenseVal.text = stats.defenseIV.ToString();
		stats.attaqueSpeIV = PlayerPrefs.GetInt(pers.pokemonType + "AttaqueSpeIV");
		IVAttSpeVal.text = stats.attaqueSpeIV.ToString();
		stats.defenseSpeIV = PlayerPrefs.GetInt(pers.pokemonType + "DefenseSpeIV");
		IVDefSpeVal.text = stats.defenseSpeIV.ToString();
		stats.PVIV = PlayerPrefs.GetInt(pers.pokemonType + "PVIV");
		IVPVVal.text = stats.PVIV.ToString();
		stats.vitesseIV = PlayerPrefs.GetInt(pers.pokemonType + "VitesseIV");
		IVVitesseVal.text = stats.vitesseIV.ToString();

		stats.attaqueEV = PlayerPrefs.GetInt(pers.pokemonType + "AttaqueEV");
		EVAttaqueVal.text = stats.attaqueEV.ToString();
		stats.defenseEV = PlayerPrefs.GetInt(pers.pokemonType + "DefenseEV");
		EVDefenseVal.text = stats.defenseEV.ToString();
		stats.attaqueSpeEV = PlayerPrefs.GetInt(pers.pokemonType + "AttaqueSpeEV");
		EVAttSpeVal.text = stats.attaqueSpeEV.ToString();
		stats.defenseSpeEV = PlayerPrefs.GetInt(pers.pokemonType + "DefenseSpeEV");
		EVDefSpeVal.text = stats.defenseSpeEV.ToString();
		stats.PVEV = PlayerPrefs.GetInt(pers.pokemonType + "PVEV");
		EVPVVal.text = stats.PVEV.ToString();
		stats.vitesseEV = PlayerPrefs.GetInt(pers.pokemonType + "VitesseEV");
		EVVitesseVal.text = stats.vitesseEV.ToString();
	}

	void RefreshButtons() {
	}
}
