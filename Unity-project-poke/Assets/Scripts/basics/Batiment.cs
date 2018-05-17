using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Batiment : MonoBehaviour {

	public Dresseur dresseur;
	public Vector3 popOfset;
	public GameObject perso;

	private statistics stat;
	private int old_pv;

	// Use this for initialization
	void Start () {
		stat = transform.GetComponent<statistics>();
		old_pv = -1;
	}
	
	// Update is called once per frame
	void Update () {
		if (old_pv == -1)
			old_pv = stat.PVActu;
		if (old_pv != stat.PVActu) {
			if (((old_pv * 100) / stat.PV) / 20 != ((stat.PVActu * 100) / stat.PV) / 20) {
				Dresseur instance = Instantiate(dresseur, transform.position + popOfset * 0.16f, Quaternion.Euler(0, 0, 0));
				instance.agro = perso;
			}
			old_pv = stat.PVActu;
		}
	}
}
