using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum PhysicType {None, Acier, Combat, Dragon, Eau, Electrik, Fee, Feu, Glace, Insecte, Normal, Plante, Poison, Psy, Roche, Sol, Spectre, Tenebres, Vol};
public enum XPCourbe {None, Rapide, Moyenne, Parabolique, Lente, Erratique, Fluctuante};

public class statistics : MonoBehaviour {

	public bool autoDestroy = true;

	public int PVBasic = 35;
	public int attaqueBasic = 55;
	public int defenseBasic = 40;
	public int attaqueSpeBasic = 50;
	public int defenseSpeBasic = 50;
	public int vitesseBasic = 90;
	public int XPBasic = 90;

	public XPCourbe courbeXP;

	public PhysicType type1;
	public PhysicType type2;

	public bool lifeInGUI = false;
	private Slider PVSlider;
	private Text PVText;
	private Slider XPSlider;
	private Text XPText;
	private Text niveauText;
	public GameObject lifeBar;

	private GameObject lifeBarInstance = null;

	[HideInInspector]public int PV = 35;
	[HideInInspector]public int attaque = 55;
	[HideInInspector]public int defense = 40;
	[HideInInspector]public int attaqueSpe = 50;
	[HideInInspector]public int defenseSpe = 50;
	[HideInInspector]public int vitesse = 90;
	[HideInInspector]public int XP = 90;

	public int PVActu = 35;
	public int XPActu = 35;

	[HideInInspector]public int PVIV = 0;
	[HideInInspector]public int attaqueIV = 0;
	[HideInInspector]public int defenseIV = 0;
	[HideInInspector]public int attaqueSpeIV = 0;
	[HideInInspector]public int defenseSpeIV = 0;
	[HideInInspector]public int vitesseIV = 0;

	[HideInInspector]public int PVEV = 0;
	[HideInInspector]public int attaqueEV = 0;
	[HideInInspector]public int defenseEV = 0;
	[HideInInspector]public int attaqueSpeEV = 0;
	[HideInInspector]public int defenseSpeEV = 0;
	[HideInInspector]public int vitesseEV = 0;

	public int niveau = 1;

	public List<Coin> coins;

	// Use this for initialization
	void Start () {
		CalculStatistiques();
		PVActu = PV;
		XPActu = 0;
		if (lifeInGUI) {
			PVSlider = GameObject.Find("PV").GetComponent<Slider>();
			PVText = GameObject.Find("PVText").GetComponent<Text>();
			XPSlider = GameObject.Find("XP").GetComponent<Slider>();
			XPText = GameObject.Find("XPText").GetComponent<Text>();
			niveauText = GameObject.Find("niveauText").GetComponent<Text>();
		}
	}
	
	// Update is called once per frame
	void Update () {
		ShowLife();
		ShowXP();
	}

	public void CalculStatistiques() {
		PV = ((2 * PVBasic + PVIV + PVEV / 4) * niveau) / 100 + niveau + 10;

		attaque = ((2 * attaqueBasic + attaqueIV + attaqueEV / 4) * niveau) / 100 + 5;
		defense = ((2 * defenseBasic + defenseIV + defenseEV / 4) * niveau) / 100 + 5;
		attaqueSpe = ((2 * attaqueSpeBasic + attaqueSpeIV + attaqueSpeEV / 4) * niveau) / 100 + 5;
		defenseSpe = ((2 * defenseSpeBasic + defenseSpeIV + defenseSpeEV / 4) * niveau) / 100 + 5;
		vitesse = ((2 * vitesseBasic + vitesseIV + vitesseEV / 4) * niveau) / 100 + 5;

		XP = CalculCourbe(niveau);
	}

	public int CalculCourbe(int lvl) {

		int result = 0;

		switch(courbeXP) {
			case XPCourbe.Moyenne:
				result = lvl * lvl * lvl;
				break;
			case XPCourbe.Parabolique:
				result = (int)(1.2f * lvl * lvl * lvl - 15f * lvl * lvl + 100f * lvl - 140f);
				if (result <= 0)
					result = 1;
				break;
		}
		return result;
	}

	void ShowLife() {
		if (lifeInGUI) {
			PVSlider.maxValue = PV;
			PVSlider.value = PVActu;
			PVText.text = PVActu.ToString() + " / " + PV.ToString();
		}
		else if (PV > PVActu) {
			if (!lifeBarInstance) {
				lifeBarInstance = Instantiate(lifeBar, transform);
				lifeBarInstance.transform.localScale = new Vector3(GetComponent<Renderer>().bounds.size.x / 0.16f, 0.2f, 1);
			}
			lifeBarInstance.transform.GetChild(0).localScale = new Vector3((float)PVActu / (float)PV, 1, 1);
		}
		else if (lifeBarInstance)
			Destroy(lifeBarInstance);
		if (PVActu > PV)
			PVActu = PV;
	}

	void ShowXP() {
		if (lifeInGUI) {
			while (XPActu >= XP) {
				XPActu -= XP;
				niveau++;
				CalculStatistiques();
				PVActu = PV;
			}
			XPSlider.maxValue = XP;
			XPSlider.value = XPActu;
			XPText.text = XPActu.ToString() + " / " + XP.ToString();
			niveauText.text = "niveau\n" + niveau.ToString();
		}
	}

	// http://www.pokepedia.fr/Calcul_des_d%C3%A9g%C3%A2ts
	public void SetDamage(Attaque attaque, statistics enemy) {
		int damage = 0;
		if (attaque.categorie == Categorie.Physique)
			damage = (int)(((float)enemy.niveau * 0.4f + 2f) * enemy.attaque * attaque.puissance) / (defense * 50) + 2;
		else if (attaque.categorie == Categorie.Special)
			damage = (int)(((float)enemy.niveau * 0.4f + 2f) * enemy.attaqueSpe * attaque.puissance) / (defenseSpe * 50) + 2;

		PVActu -= damage;
		if (PVActu < 0)
			PVActu = 0;

		if (PVActu == 0 && !lifeInGUI) {
			for (int i = 0 ; i < coins.Count ; i++) {
				coins[i].gameObject.SetActive(true);
				coins[i].gameObject.transform.SetParent(null);
			}
			enemy.XPActu += ((XPBasic * niveau) / 7);
			if (autoDestroy) {
				for (int i = transform.childCount - 1 ; i >= 0 ; i--) {
					if (transform.GetChild(i).gameObject.activeSelf && transform.GetChild(i).gameObject.GetComponent<statistics>()) {
						transform.GetChild(i).SetParent(null);
						transform.GetChild(i).gameObject.GetComponent<statistics>().autoDestroy = true;
					}
				}
				Destroy(gameObject);
			}
			return ;
		}
	}
}
