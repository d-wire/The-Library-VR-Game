using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float speed = 5.0f;
    public float duration = 2.0f;
    protected Vector3 direction;
    private float initializationTime;

	// Use this for initialization
	void Start () {
        var rot = Quaternion.Euler(Camera.main.transform.eulerAngles);
        var yangle = rot * Vector3.forward;
        direction = yangle * speed;
        initializationTime = Time.timeSinceLevelLoad;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += direction;
        float timeSinceInitialization = Time.timeSinceLevelLoad - initializationTime;
        if(timeSinceInitialization > duration)
        {
            Destroy(gameObject);
        }
	}

    protected void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Structure" )
        {
            Destroy(gameObject);
        }
		else if (other.tag == "Burnable"){
			Destroy(other.gameObject);
		}
    }
}
