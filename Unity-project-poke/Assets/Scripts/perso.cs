using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class perso : MonoBehaviour {

	private Move move;
	public Attaque[] attaques = new Attaque[4];

	private Text zoneText;
	private Text destrucText;

	// Use this for initialization
	void Start () {
		move = GetComponent<Move>();
		zoneText = GameObject.Find("ZoneText").GetComponent<Text>();
		destrucText = GameObject.Find("DestrucText").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		Orientation();
		Move();
		if (Input.GetKeyDown("space"))
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
		Vector3 vec = Vector3.zero;

		if (Input.GetKey("w"))
			vec.y += 1;
		if (Input.GetKey("s"))
			vec.y -= 1;
		if (Input.GetKey("d"))
			vec.x += 1;
		if (Input.GetKey("a"))
			vec.x -= 1;

		move.Moving(vec);
	}

	void OnTriggerEnter2D(Collider2D other)
    {
    	Dresseur dresseur = other.gameObject.GetComponent<Dresseur>();
        if (dresseur)
        	dresseur.agro = gameObject;
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
