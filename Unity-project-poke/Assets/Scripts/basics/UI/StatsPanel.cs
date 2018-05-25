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

	// Use this for initialization
	void Start () {
		stats = pers.transform.gameObject.GetComponent<statistics>();
		CoinsName.text = pers.pokemonType + " Coin :";
		CoinsVal.text = PlayerPrefs.GetInt(pers.pokemonType + "Coin").ToString();
		RefreshVal();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void RefreshVal() {
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

		CoinsName.text = pers.pokemonType + " Coin :";
		CoinsVal.text = PlayerPrefs.GetInt(pers.pokemonType + "Coin").ToString();

		RefreshButtons();
	}

	void RefreshButtons() {
	}

	public void IVAttaqueUpButton() {
		int nextLvl = PlayerPrefs.GetInt(pers.pokemonType + "AttaqueIV") + 1;
		int cost = stats.CalculCourbe(nextLvl);
		int Coins = PlayerPrefs.GetInt(pers.pokemonType + "Coin");
		if (cost <= Coins) {
			PlayerPrefs.SetInt(pers.pokemonType + "AttaqueIV", nextLvl);
			PlayerPrefs.SetInt(pers.pokemonType + "Coin", Coins - cost);
			RefreshVal();
			stats.CalculStatistiques();
		}
	}

	public void IVDefenseUpButton() {
		int nextLvl = PlayerPrefs.GetInt(pers.pokemonType + "DefenseIV") + 1;
		int cost = stats.CalculCourbe(nextLvl);
		int Coins = PlayerPrefs.GetInt(pers.pokemonType + "Coin");
		if (cost <= Coins) {
			PlayerPrefs.SetInt(pers.pokemonType + "DefenseIV", nextLvl);
			PlayerPrefs.SetInt(pers.pokemonType + "Coin", Coins - cost);
			RefreshVal();
			stats.CalculStatistiques();
		}
	}

	public void IVAttaqueSpeUpButton() {
		int nextLvl = PlayerPrefs.GetInt(pers.pokemonType + "AttaqueSpeIV") + 1;
		int cost = stats.CalculCourbe(nextLvl);
		int Coins = PlayerPrefs.GetInt(pers.pokemonType + "Coin");
		if (cost <= Coins) {
			PlayerPrefs.SetInt(pers.pokemonType + "AttaqueSpeIV", nextLvl);
			PlayerPrefs.SetInt(pers.pokemonType + "Coin", Coins - cost);
			RefreshVal();
			stats.CalculStatistiques();
		}
	}

	public void IVDefenseSpeUpButton() {
		int nextLvl = PlayerPrefs.GetInt(pers.pokemonType + "DefenseSpeIV") + 1;
		int cost = stats.CalculCourbe(nextLvl);
		int Coins = PlayerPrefs.GetInt(pers.pokemonType + "Coin");
		if (cost <= Coins) {
			PlayerPrefs.SetInt(pers.pokemonType + "DefenseSpeIV", nextLvl);
			PlayerPrefs.SetInt(pers.pokemonType + "Coin", Coins - cost);
			RefreshVal();
			stats.CalculStatistiques();
		}
	}

	public void IVPVUpButton() {
		int nextLvl = PlayerPrefs.GetInt(pers.pokemonType + "PVIV") + 1;
		int cost = stats.CalculCourbe(nextLvl);
		int Coins = PlayerPrefs.GetInt(pers.pokemonType + "Coin");
		if (cost <= Coins) {
			PlayerPrefs.SetInt(pers.pokemonType + "PVIV", nextLvl);
			PlayerPrefs.SetInt(pers.pokemonType + "Coin", Coins - cost);
			RefreshVal();
			stats.CalculStatistiques();
		}
	}

	public void IVVitesseUpButton() {
		int nextLvl = PlayerPrefs.GetInt(pers.pokemonType + "VitesseIV") + 1;
		int cost = stats.CalculCourbe(nextLvl);
		int Coins = PlayerPrefs.GetInt(pers.pokemonType + "Coin");
		if (cost <= Coins) {
			PlayerPrefs.SetInt(pers.pokemonType + "VitesseIV", nextLvl);
			PlayerPrefs.SetInt(pers.pokemonType + "Coin", Coins - cost);
			RefreshVal();
			stats.CalculStatistiques();
		}
	}

	public void EVAttaqueUpButton() {
		int nextLvl = PlayerPrefs.GetInt(pers.pokemonType + "AttaqueEV") + 1;
		int cost = 10;
		int Coins = PlayerPrefs.GetInt(pers.pokemonType + "Coin");
		if (cost <= Coins) {
			PlayerPrefs.SetInt(pers.pokemonType + "AttaqueEV", nextLvl);
			PlayerPrefs.SetInt(pers.pokemonType + "Coin", Coins - cost);
			RefreshVal();
			stats.CalculStatistiques();
		}
	}

	public void EVDefenseUpButton() {
		int nextLvl = PlayerPrefs.GetInt(pers.pokemonType + "DefenseEV") + 1;
		int cost = 10;
		int Coins = PlayerPrefs.GetInt(pers.pokemonType + "Coin");
		if (cost <= Coins) {
			PlayerPrefs.SetInt(pers.pokemonType + "DefenseEV", nextLvl);
			PlayerPrefs.SetInt(pers.pokemonType + "Coin", Coins - cost);
			RefreshVal();
			stats.CalculStatistiques();
		}
	}

	public void EVAttaqueSpeUpButton() {
		int nextLvl = PlayerPrefs.GetInt(pers.pokemonType + "AttaqueSpeEV") + 1;
		int cost = 10;
		int Coins = PlayerPrefs.GetInt(pers.pokemonType + "Coin");
		if (cost <= Coins) {
			PlayerPrefs.SetInt(pers.pokemonType + "AttaqueSpeEV", nextLvl);
			PlayerPrefs.SetInt(pers.pokemonType + "Coin", Coins - cost);
			RefreshVal();
			stats.CalculStatistiques();
		}
	}

	public void EVDefenseSpeUpButton() {
		int nextLvl = PlayerPrefs.GetInt(pers.pokemonType + "DefenseSpeEV") + 1;
		int cost = 10;
		int Coins = PlayerPrefs.GetInt(pers.pokemonType + "Coin");
		if (cost <= Coins) {
			PlayerPrefs.SetInt(pers.pokemonType + "DefenseSpeEV", nextLvl);
			PlayerPrefs.SetInt(pers.pokemonType + "Coin", Coins - cost);
			RefreshVal();
			stats.CalculStatistiques();
		}
	}

	public void EVPVUpButton() {
		int nextLvl = PlayerPrefs.GetInt(pers.pokemonType + "PVEV") + 1;
		int cost = 10;
		int Coins = PlayerPrefs.GetInt(pers.pokemonType + "Coin");
		if (cost <= Coins) {
			PlayerPrefs.SetInt(pers.pokemonType + "PVEV", nextLvl);
			PlayerPrefs.SetInt(pers.pokemonType + "Coin", Coins - cost);
			RefreshVal();
			stats.CalculStatistiques();
		}
	}

	public void EVVitesseUpButton() {
		int nextLvl = PlayerPrefs.GetInt(pers.pokemonType + "VitesseEV") + 1;
		int cost = 10;
		int Coins = PlayerPrefs.GetInt(pers.pokemonType + "Coin");
		if (cost <= Coins) {
			PlayerPrefs.SetInt(pers.pokemonType + "VitesseEV", nextLvl);
			PlayerPrefs.SetInt(pers.pokemonType + "Coin", Coins - cost);
			RefreshVal();
			stats.CalculStatistiques();
		}
	}

	public void EVAttaqueDownButton() {
		int nextLvl = PlayerPrefs.GetInt(pers.pokemonType + "AttaqueEV") - 1;
		int cost = 5;
		int Coins = PlayerPrefs.GetInt(pers.pokemonType + "Coin");
		if (nextLvl >= 0) {
			PlayerPrefs.SetInt(pers.pokemonType + "AttaqueEV", nextLvl);
			PlayerPrefs.SetInt(pers.pokemonType + "Coin", Coins + cost);
			RefreshVal();
			stats.CalculStatistiques();
		}
	}

	public void EVDefenseDownButton() {
		int nextLvl = PlayerPrefs.GetInt(pers.pokemonType + "DefenseEV") - 1;
		int cost = 5;
		int Coins = PlayerPrefs.GetInt(pers.pokemonType + "Coin");
		if (nextLvl >= 0) {
			PlayerPrefs.SetInt(pers.pokemonType + "DefenseEV", nextLvl);
			PlayerPrefs.SetInt(pers.pokemonType + "Coin", Coins + cost);
			RefreshVal();
			stats.CalculStatistiques();
		}
	}

	public void EVAttaqueSpeDownButton() {
		int nextLvl = PlayerPrefs.GetInt(pers.pokemonType + "AttaqueSpeEV") - 1;
		int cost = 5;
		int Coins = PlayerPrefs.GetInt(pers.pokemonType + "Coin");
		if (nextLvl >= 0) {
			PlayerPrefs.SetInt(pers.pokemonType + "AttaqueSpeEV", nextLvl);
			PlayerPrefs.SetInt(pers.pokemonType + "Coin", Coins + cost);
			RefreshVal();
			stats.CalculStatistiques();
		}
	}

	public void EVDefenseSpeDownButton() {
		int nextLvl = PlayerPrefs.GetInt(pers.pokemonType + "DefenseSpeEV") - 1;
		int cost = 5;
		int Coins = PlayerPrefs.GetInt(pers.pokemonType + "Coin");
		if (nextLvl >= 0) {
			PlayerPrefs.SetInt(pers.pokemonType + "DefenseSpeEV", nextLvl);
			PlayerPrefs.SetInt(pers.pokemonType + "Coin", Coins + cost);
			RefreshVal();
			stats.CalculStatistiques();
		}
	}

	public void EVPVDownButton() {
		int nextLvl = PlayerPrefs.GetInt(pers.pokemonType + "PVEV") - 1;
		int cost = 5;
		int Coins = PlayerPrefs.GetInt(pers.pokemonType + "Coin");
		if (nextLvl >= 0) {
			PlayerPrefs.SetInt(pers.pokemonType + "PVEV", nextLvl);
			PlayerPrefs.SetInt(pers.pokemonType + "Coin", Coins + cost);
			RefreshVal();
			stats.CalculStatistiques();
		}
	}

	public void EVVitesseDownButton() {
		int nextLvl = PlayerPrefs.GetInt(pers.pokemonType + "VitesseEV") - 1;
		int cost = 5;
		int Coins = PlayerPrefs.GetInt(pers.pokemonType + "Coin");
		if (nextLvl >= 0) {
			PlayerPrefs.SetInt(pers.pokemonType + "VitesseEV", nextLvl);
			PlayerPrefs.SetInt(pers.pokemonType + "Coin", Coins + cost);
			RefreshVal();
			stats.CalculStatistiques();
		}
	}
}
