using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TurnOnAliens : MonoBehaviour {
	int i;

	// Use this for initialization
	void Start () {
		
		InvokeRepeating ("TurnOn", 2f, 1f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void TurnOn(){
		if(i<this.transform.childCount)
			this.transform.GetChild (i).gameObject.SetActive (true);
		i++;
	}
}
