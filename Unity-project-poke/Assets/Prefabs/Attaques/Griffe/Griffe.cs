using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Griffe : Attaque {

	private Vector3 dir;
	private float start;
	private float chargement = 0.5f;
	public SpriteRenderer spriteZone;
	private string buttonPressed = "";
	private CircleCollider2D collide;
	private List<statistics> listColliders = new List<statistics>();

	// Use this for initialization
	void Start () {
		collide = GetComponent<CircleCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if (isRunning) {
			if ((start + chargement) > Time.time && !(buttonPressed != "" && Input.GetKeyUp(buttonPressed))) {
				spriteZone.transform.localScale = new Vector3(1 + (((Time.time - start) / chargement)), 1 + (((Time.time - start) / chargement)), 1);
				collide.radius = 0.08f * (1 + (((Time.time - start) / chargement)));
				return ;
			}
			else {
				spriteZone.gameObject.SetActive(false);
				for (int i = 0 ; i < listColliders.Count ; i++) {
					if (listColliders[i].transform.gameObject != pers.gameObject && listColliders[i].transform.gameObject.GetComponent<statistics>())
						listColliders[i].transform.gameObject.GetComponent<statistics>().SetDamage(this, pers.GetComponent<statistics>());
				}
				isRunning = false;
			}

		}
	}

	public override void Fire(string buttonPressed) {
		if (lastSend + 35f / (float)PP < Time.time) {
			this.buttonPressed = buttonPressed;
			isRunning = true;
			start = Time.time;
			dir = pers.GetDir();
			lastSend = Time.time + chargement;
			spriteZone.gameObject.SetActive(true);
			transform.rotation = Quaternion.Euler(0f, 0f, dir.x * 90f + ((dir.y == 1) ? 180f : 0f));
			spriteZone.transform.localScale = new Vector3(1, 1, 1);
			collide.radius = 0.08f;
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
    	statistics adv = other.gameObject.GetComponent<statistics>();
        if (adv && !other.isTrigger) {
        	listColliders.Add(adv);
		}
    }

	void OnTriggerExit2D(Collider2D other) {
    	statistics adv = other.gameObject.GetComponent<statistics>();
        if (adv) {
        	for (int i = 0 ; i < listColliders.Count ; i++) {
        		if (adv == listColliders[i]) {
        			listColliders.RemoveAt(i);
        			break ;
        		}
        	}
		}
    }
}
