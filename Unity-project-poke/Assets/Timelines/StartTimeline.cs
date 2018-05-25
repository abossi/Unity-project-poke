using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class StartTimeline : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//if (GetComponent<PlayableDirector>().currentTime >= 100)
		//	Destroy(gameObject);
		if (Input.GetKeyDown("space")) {
			GetComponent<PlayableDirector>().time = GetComponent<PlayableDirector>().duration;
		}
	}
}
