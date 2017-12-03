using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningProjectile : Projectile
{
	protected override void handleCollision(Collider other)
	{
		if (other.tag == "Watered" && other.gameObject.GetComponent<ObjectScript>().zappable){
			Destroy(gameObject);
			other.tag = "Zapped";
		}
	}
}

