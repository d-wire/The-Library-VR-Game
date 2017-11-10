using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateDepressable : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Spell")
		{
			Destroy(other.gameObject);
			this.gameObject.GetComponent<MeshRenderer> ().enabled = true;
		}
	}

}
