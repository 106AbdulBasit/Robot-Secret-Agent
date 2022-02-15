using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour {

	public Transform target;
	// Use this for initialization
	void Start () {
		//target = GameObject.FindWithTag ("PlayerTarget").transform;
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt (target);
	}
}
