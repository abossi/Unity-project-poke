using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealZone : MonoBehaviour {

	int time;
	int old_time;
	List<statistics> listToHeal = new List<statistics>();

	// Use this for initialization
	void Start () {
		time = (int)Time.time;
		old_time = time;
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		old_time = time;
		time = (int)Time.time;
        if (time != old_time) {
			for (int i = 0 ; i < listToHeal.Count ; i++) {
				if (listToHeal[i].PVActu < listToHeal[i].PV) {
					listToHeal[i].PVActu++;
				}
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other)
    {
		perso pers = other.gameObject.GetComponent<perso>();
		if (pers && !other.isTrigger) {
			pers.lastHealZone = this;
		}
    	statistics stat = other.gameObject.GetComponent<statistics>();
        if (stat && other.isTrigger == false)
        	listToHeal.Add(stat);
    }

	void OnTriggerExit2D(Collider2D other)
    {
    	statistics stat = other.gameObject.GetComponent<statistics>();
        if (stat && other.isTrigger == false) {
			for (int i = 0 ; i < listToHeal.Count ; i++) {
				if (listToHeal[i] == stat) {
					listToHeal.RemoveAt(i);
					break ;
				}
			}
		}
    }
}
