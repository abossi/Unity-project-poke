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
		if (Input.GetKeyDown("space") && lastSend + 35f / (float)PP < Time.time) {
			isRunning = true;
			power = 5;
			dir = pers.GetDir();
			lastSend = Time.time;
		}
		if (isRunning) {
			pers.transform.Translate(dir * power * Time.deltaTime);
			power /= 2;

			RaycastHit2D[] hits = Physics2D.RaycastAll(pers.transform.position, dir, 0.08f);
			if (hits.Length >= 2 && hits[1].transform.gameObject.GetComponent<statistics>() && hits[1].transform.gameObject != pers.gameObject) {
				hits[1].transform.gameObject.GetComponent<statistics>().SetDamage(this, pers.GetComponent<statistics>());
				power = 0;
			}

			if (power == 0)
				isRunning = false;
		}
	}
}
