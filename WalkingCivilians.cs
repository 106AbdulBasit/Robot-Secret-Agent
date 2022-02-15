using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingCivilians : MonoBehaviour {
	
	Animator anim;
	// Use this for initialization
	void Start () {
		anim = this.transform.GetComponent<Animator> ();
		anim.Play ("Idle");
	}

	// Update is called once per frame
	void Update () {

	}
}
