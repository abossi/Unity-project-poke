using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class perso : MonoBehaviour {

	private Move move;
	[HideInInspector]public HealZone lastHealZone;
	[HideInInspector]public bool justDead = false;
	private statistics stat;
	public Attaque[] attaques = new Attaque[4];
	public Image[] images = new Image[4];

	public Text textChat;
	public GameObject contentChat;

	private Text zoneText;
	private Text destrucText;

	private GameObject starter;

	public Pokemon pokemonType;
	public StatsPanel statsPanel;

	// Use this for initialization
	void Start () {

		move = GetComponent<Move>();
		stat = GetComponent<statistics>();
		zoneText = GameObject.Find("ZoneText").GetComponent<Text>();
		destrucText = GameObject.Find("DestrucText").GetComponent<Text>();

		starter = GameObject.Find("Starter").GetComponent<SelectPokemonStart>().prefabPoke;
		pokemonType = (Pokemon)GameObject.Find("Starter").GetComponent<SelectPokemonStart>().pokemonType;
		stat.PVBasic = starter.GetComponent<statistics>().PVBasic;
		stat.attaqueBasic = starter.GetComponent<statistics>().attaqueBasic;
		stat.defenseBasic = starter.GetComponent<statistics>().defenseBasic;
		stat.attaqueSpeBasic = starter.GetComponent<statistics>().attaqueSpeBasic;
		stat.defenseSpeBasic = starter.GetComponent<statistics>().defenseSpeBasic;
		stat.vitesseBasic = starter.GetComponent<statistics>().vitesseBasic;
		stat.XPBasic = starter.GetComponent<statistics>().XPBasic;
		stat.courbeXP = starter.GetComponent<statistics>().courbeXP;
		stat.type1 = starter.GetComponent<statistics>().type1;
		stat.type2 = starter.GetComponent<statistics>().type2;
		stat.niveau = 1;
		GetComponent<Animator>().runtimeAnimatorController = starter.GetComponent<Animator>().runtimeAnimatorController;
		stat.CalculStatistiques();
		GameObject inst = Instantiate(starter.transform.GetChild(0), transform).gameObject;
		attaques[0] = inst.GetComponent<Attaque>();
		attaques[0].pers = move;

		GameObject parents = GameObject.Find("Starter").GetComponent<SelectPokemonStart>().prefabPokeParent;
		GameObject.Find("papa").GetComponent<SpriteRenderer>().sprite = parents.GetComponent<SpriteRenderer>().sprite;
		GameObject.Find("maman").GetComponent<SpriteRenderer>().sprite = parents.GetComponent<SpriteRenderer>().sprite;
		Destroy(GameObject.Find("Starter"));

		for (int i = 0 ; i < 4 ; i++) {
			if (attaques[i]) {
				images[i].sprite = attaques[i].spriteGUI;
				images[i].color = new Color(255, 255, 255, 1);
			}
			images[i].transform.GetChild(0).GetComponent<Text>().text = "";
		}
	}
	
	// Update is called once per frame
	void Update () {
		//Orientation();
		Move();
		if (Input.GetKey("1") && attaques[0] && !attaques[0].isRunning)
			attaques[0].Fire("1");
		if (Input.GetKey("2") && attaques[1] && !attaques[1].isRunning)
			attaques[1].Fire("2");
		if (Input.GetKey("3") && attaques[2] && !attaques[2].isRunning)
			attaques[2].Fire("3");
		if (Input.GetKey("4") && attaques[3] && !attaques[3].isRunning)
			attaques[3].Fire("4");
		if (Input.GetKeyDown("space")) {
			Interaction();
		}
		UpdateZone();
		CallDownAttaques();
	}

	void CallDownAttaques() {
		for (int i = 0 ; i < 4 ; i++) {
			if (attaques[i]) {
				if (attaques[i].lastSend + 35f / (float)attaques[i].PP < Time.time) {
					images[i].color = new Color(255, 255, 255, 1);
					images[i].transform.GetChild(0).GetComponent<Text>().text = "";
				}
				else {
					if ((attaques[i].lastSend + 35f / (float)attaques[i].PP) - Time.time >= 1)
						images[i].transform.GetChild(0).GetComponent<Text>().text = ((int)((attaques[i].lastSend + 35f / (float)attaques[i].PP) - Time.time)).ToString();
					else
						images[i].transform.GetChild(0).GetComponent<Text>().text = ((int)(100f * ((attaques[i].lastSend + 35f / (float)attaques[i].PP) - Time.time))).ToString();
					images[i].color = new Color(0.5f, 0.5f, 0.5f, 1f);
				}
			}
		}
	}

	void Interaction() {
    	RaycastHit2D[] hits = Physics2D.RaycastAll(move.Center(), Vector3.back, 0.08f);
    	for (int i = 0 ; i < hits.Length ; i++) {
    		if (hits[i].transform.gameObject.layer == LayerMask.NameToLayer("herbe")) {
    			Destroy(hits[i].transform.gameObject);
    			stat.PVActu += (stat.PV * 10) / 100;
    			if (stat.PVActu > stat.PV)
    				stat.PVActu = stat.PV;
    			break;
    		}
    		if (hits[i].transform.gameObject.layer == LayerMask.NameToLayer("Coin")) {
    			Coin coin = hits[i].transform.gameObject.GetComponent<Coin>();
    			Text inst = Instantiate(textChat, contentChat.transform);

        		PlayerPrefs.SetInt(coin.pokemon + "Coin", PlayerPrefs.GetInt(coin.pokemon + "Coin") + coin.quantity);
    			inst.text = coin.pokemon + " coin X " + coin.quantity.ToString() + " => " + PlayerPrefs.GetInt(coin.pokemon + "Coin").ToString();

    			statsPanel.RefreshVal();
    			
    			Destroy(hits[i].transform.gameObject);
    			break;
    		}
    	}
	}

	void Orientation() {
		Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		pz.z = 0;
		float angle = Vector2.SignedAngle(Vector3.down, pz - transform.position);
		
		move.Orientation(angle);
	}

	void Move() {
		if (stat.PVActu == 0) {
			transform.position = lastHealZone.transform.position;
			stat.PVActu = stat.PV;
			justDead = true;
			return ;
		}
		justDead = false;

		for (int i = 0 ; i < 4 ; i++) {
			if (attaques[i] && attaques[i].isRunning)
				return ;
		}

		Vector3 vec = Vector3.zero;
		if (Input.GetKeyDown("up"))
			move.Orientation(180);
		if (Input.GetKeyDown("down"))
			move.Orientation(0);
		if (Input.GetKeyDown("right"))
			move.Orientation(90);
		if (Input.GetKeyDown("left"))
			move.Orientation(-90);

		if (Input.GetKey("up"))
			vec.y += 1;
		if (Input.GetKey("down"))
			vec.y -= 1;
		if (Input.GetKey("right"))
			vec.x += 1;
		if (Input.GetKey("left"))
			vec.x -= 1;

		if (Input.GetKeyUp("up") || Input.GetKeyUp("down") || Input.GetKeyUp("left") || Input.GetKeyUp("right")) {
			if (vec.x == 1)
				move.Orientation(90);
			else if (vec.x == -1)
				move.Orientation(-90);
			else if (vec.y == 1)
				move.Orientation(180);
			else if (vec.y == -1)
				move.Orientation(0);
		}

		move.Moving(vec);
	}

	void OnTriggerEnter2D(Collider2D other)
    {
    	Dresseur dresseur = other.gameObject.GetComponent<Dresseur>();
        if (dresseur) {
        	dresseur.agro = gameObject;
			return ;
		}
    }

    void UpdateZone() {
    	RaycastHit2D[] hits = Physics2D.RaycastAll(move.Center(), Vector3.back, 0.08f);
    	for (int i = 0 ; i < hits.Length ; i++) {
    		if (hits[i].transform.gameObject.layer == LayerMask.NameToLayer("Zone")) {
    			zoneText.text = hits[i].transform.gameObject.GetComponent<Zone>().name;
    			destrucText.text = hits[i].transform.gameObject.GetComponent<Zone>().destruc.ToString() + " %";
    			break;
    		}
    	}
    }
}
