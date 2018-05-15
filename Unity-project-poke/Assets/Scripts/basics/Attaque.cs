using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Categorie {Physique, Special, Statut};

public class Attaque : MonoBehaviour {

	public PhysicType type;
	public Categorie categorie;
	public int PP;
	public int puissance;
	public int precision;

	public perso pers;

	public float lastSend;

	// Use this for initialization
	void Start () {
		lastSend = Time.time - 1000;
	}
	
	// Update is called once per frame
	void Update () {
	}
}
