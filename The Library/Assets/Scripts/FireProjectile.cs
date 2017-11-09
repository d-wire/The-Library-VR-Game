using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectile : Projectile {
	protected override void handleCollision(Collider other){
		if (other.tag == "Structure" )
		{
			Destroy(gameObject);
		}
		else if (other.tag == "Object" && other.gameObject.GetComponent<ObjectScript>().burnable){
            Destroy(other.gameObject);
            Destroy(gameObject);
		}
	}
}
