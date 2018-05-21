using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charge : Attaque {

	private int power;
	private Vector3 dir;
	private float start;
	private float chargement = 0.5f;
	public SpriteRenderer spriteZone;
	private string buttonPressed = "";

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (isRunning) {
			if ((start + chargement) > Time.time && !(buttonPressed != "" && Input.GetKeyUp(buttonPressed))) {
				spriteZone.color = new Color(255, 255, 255, (((Time.time - start) / chargement)));
				return ;
			}
			else {
				spriteZone.gameObject.SetActive(false);
				pers.transform.Translate(dir * power * Time.deltaTime);
				power /= 2;

				RaycastHit2D[] hits = Physics2D.RaycastAll(pers.Center(), dir, pers.Radius());
				int num = 0;
				for ( ; num < hits.Length ; num++) {
					if (hits[num].transform.gameObject != pers.gameObject && hits[num].transform.gameObject.GetComponent<statistics>())
						break ;
				}
				if (hits.Length >= 2 && num < hits.Length) {
					int puissanceBase = puissance;
					puissance += (int)(((Time.time - start) / chargement) * 50f);
					hits[num].transform.gameObject.GetComponent<statistics>().SetDamage(this, pers.GetComponent<statistics>());
					puissance = puissanceBase;
					power = 0;
				}
			}

			if (power == 0)
				isRunning = false;
		}
	}

	public override void Fire(string buttonPressed) {
		if (lastSend + 35f / (float)PP < Time.time) {
			this.buttonPressed = buttonPressed;
			isRunning = true;
			start = Time.time;
			power = 5;
			dir = pers.GetDir();
			lastSend = Time.time + chargement;
			spriteZone.gameObject.SetActive(true);
			transform.rotation = Quaternion.Euler(0f, 0f, dir.x * 90f + ((dir.y == 1) ? 180f : 0f));
		}
	}
}
