using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchObject : ObjectScript {

	// Use this for initialization
	void Start () {
		Rigidbody rb = GetComponent<Rigidbody> (); 
		rb.AddForce (new Vector3(0f,1000f,1000f));
	}

}
