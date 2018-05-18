using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charge : Attaque {

	private bool isRunning = false;
	private int power;
	private Vector3 dir;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (isRunning) {
			pers.transform.Translate(dir * power * Time.deltaTime);
			power /= 2;

			RaycastHit2D[] hits = Physics2D.RaycastAll(pers.transform.position + new Vector3(0.08f, -0.1f, 0), dir, 0.08f);
			int num = 0;
			for ( ; num < hits.Length ; num++) {
				if (hits[num].transform.gameObject != pers.gameObject && hits[num].transform.gameObject.GetComponent<statistics>())
					break ;
			}
			if (hits.Length >= 2 && num < hits.Length) {
				hits[num].transform.gameObject.GetComponent<statistics>().SetDamage(this, pers.GetComponent<statistics>());
				power = 0;
			}

			if (power == 0)
				isRunning = false;
		}
	}

	public override void Fire() {
		if (lastSend + 35f / (float)PP < Time.time) {
			isRunning = true;
			power = 5;
			dir = pers.GetDir();
			lastSend = Time.time;
		}
	}
}
