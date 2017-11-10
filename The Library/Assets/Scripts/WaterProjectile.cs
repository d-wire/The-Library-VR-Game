using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterProjectile : Projectile
{
    protected override void handleCollision(Collider other)
    {
        if (other.tag == "Structure")
        {
            Destroy(gameObject);
        }
        else if (other.tag == "Object" && other.gameObject.GetComponent<ObjectScript>().fillable)
        {
            Destroy(gameObject);
            other.gameObject.GetComponent<Renderer>().material.color = Color.blue;
        }
    }
}
