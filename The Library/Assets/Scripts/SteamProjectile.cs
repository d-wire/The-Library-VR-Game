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
			Destroy (gameObject);
			Destroy(other.gameObject);
			GameObject door = GameObject.Find ("Door");
			door.transform.position = new Vector3(door.transform.position.x, door.transform.position.y, -4);
		}
	}
}
