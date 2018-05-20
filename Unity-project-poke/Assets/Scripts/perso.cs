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

	private Text zoneText;
	private Text destrucText;

	// Use this for initialization
	void Start () {
		move = GetComponent<Move>();
		stat = GetComponent<statistics>();
		zoneText = GameObject.Find("ZoneText").GetComponent<Text>();
		destrucText = GameObject.Find("DestrucText").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		//Orientation();
		Move();
		if (Input.GetKeyDown("1"))
			attaques[0].Fire();
		UpdateZone();
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
    	RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, Vector3.back, 0.08f);
    	for (int i = 0 ; i < hits.Length ; i++) {
    		if (hits[i].transform.gameObject.layer == LayerMask.NameToLayer("Zone")) {
    			zoneText.text = hits[i].transform.gameObject.GetComponent<Zone>().name;
    			destrucText.text = hits[i].transform.gameObject.GetComponent<Zone>().destruc.ToString() + " %";
    			break;
    		}
    	}
    }
}
