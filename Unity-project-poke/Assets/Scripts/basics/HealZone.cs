using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealZone : MonoBehaviour {

	int time;
	int old_time;

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
	}

	void OnTriggerStay2D(Collider2D other)
    {
    	statistics stat = other.gameObject.GetComponent<statistics>();
        if (stat && stat.PVActu < stat.PV && other.isTrigger == false && time != old_time)
        	stat.PVActu++;
    }
}
