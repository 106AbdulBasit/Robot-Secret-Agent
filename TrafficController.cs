using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficController : MonoBehaviour {

	public bool isFrontBlocked = false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Player" || col.gameObject.tag == "Traffic") {
			isFrontBlocked = true;
		}
	}

	void OnTriggerStay(Collider col){
		if (col.gameObject.tag == "Player" || col.gameObject.tag == "Traffic") {
			isFrontBlocked = true;
		}
	}

	void OnTriggerExit(Collider col){
		if (col.gameObject.tag == "Player" || col.gameObject.tag == "Traffic") {
			isFrontBlocked = false;
		}
	}
}
