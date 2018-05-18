using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone : MonoBehaviour {

	public int destruc = 0;
	public string name;
	public GameObject folderObstacles;
	private int obstaclesTotal;
	private int obstaclesActu;

	// Use this for initialization
	void Start () {
		name = gameObject.name;
		obstaclesTotal = folderObstacles.transform.childCount;
		obstaclesActu = obstaclesTotal;
	}
	
	// Update is called once per frame
	void Update () {
		obstaclesActu = folderObstacles.transform.childCount;
		destruc = ((obstaclesTotal - obstaclesActu) * 100) / obstaclesTotal;
	}
}
