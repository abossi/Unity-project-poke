using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Batiment : MonoBehaviour {

	public List<Dresseur> dresseurs;
	public perso pers;

	private int dresseurCount = 0;
	private statistics stat;
	private int old_pv;
	private Vector3 initialPosDresseur;

	// Use this for initialization
	void Start () {
		stat = transform.GetComponent<statistics>();
		old_pv = -1;
	}
	
	// Update is called once per frame
	void Update () {
		if (old_pv == -1) {
			old_pv = stat.PVActu;
		}
		if (old_pv != stat.PVActu) {
			if (((old_pv * 100) / stat.PV) / (100 / dresseurs.Count) != ((stat.PVActu * 100) / stat.PV) / (100 / dresseurs.Count)) {
				if (dresseurs[dresseurCount]) {
					initialPosDresseur = dresseurs[dresseurCount].transform.position;
					dresseurs[dresseurCount].transform.gameObject.SetActive(true);
					dresseurs[dresseurCount].agro = pers.transform.gameObject;
				}
				dresseurCount++;
			}
			old_pv = stat.PVActu;
		}

		if (pers.justDead && dresseurCount != 0 && dresseurs[dresseurCount - 1] && dresseurs[dresseurCount - 1].transform.gameObject.activeSelf) {
			dresseurCount--;
			stat.PVActu = stat.PV;
			old_pv = stat.PVActu;
			dresseurs[dresseurCount].transform.gameObject.SetActive(false);
			dresseurs[dresseurCount].transform.position = initialPosDresseur;
			dresseurCount = 0;
		}
	}
}
