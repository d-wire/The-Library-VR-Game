using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFallingBarrels : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Object")
		{
			Destroy(other.gameObject);
		}
	}
}
