using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamProjectile : Projectile {
	protected override void handleCollision(Collider other){
		//if (other.tag == "Structure" )
		//{
		//	Destroy(gameObject);
		//}
		if (other.tag == "Object" && other.gameObject.GetComponent<ObjectScript>().steamable){
            Debug.Log("Hit");
			Destroy (gameObject);
			other.gameObject.tag = "Steamed";
		}
	}
}
