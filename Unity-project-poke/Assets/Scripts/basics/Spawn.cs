using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

	public Dresseur dresseur;
	public float delay;

	private Dresseur copy;
	private float timeDeath;

	// Use this for initialization
	void Start () {
		copy = Instantiate(dresseur, transform);
		copy.transform.gameObject.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
		if (!copy) {
			copy = Instantiate(dresseur, transform);
			timeDeath = Time.time;
		}
		if (!copy.transform.gameObject.activeSelf && (timeDeath + delay) < Time.time)
			copy.transform.gameObject.SetActive(true);
	}
}
