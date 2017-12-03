﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneProjectile : Projectile
{
    protected override void handleCollision(Collider other)
    {
		if (other.tag == "Object" && other.gameObject.GetComponent<ObjectScript>().scorable){
			Destroy(gameObject);
			other.tag = "Score";
		}
    }
}
