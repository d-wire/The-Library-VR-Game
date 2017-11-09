using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float speed = 5.0f;
    public float duration = 4.0f;
    protected Vector3 direction;
    private float initializationTime;
    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        var rot = Quaternion.Euler(direction);
        var yangle = rot * Vector3.forward;
        rb = GetComponent<Rigidbody>();
        direction = yangle * speed;
        initializationTime = Time.timeSinceLevelLoad;
        rb.AddForce(direction * 2000*rb.mass);
    }

	// Update is called once per frame
	void Update () {

        float timeSinceInitialization = Time.timeSinceLevelLoad - initializationTime;
        if(timeSinceInitialization > duration)
        {
            Destroy(gameObject);
        }
	}

	public void OnTriggerEnter(Collider other){
		handleCollision (other);
	}

	protected virtual void handleCollision(Collider other)
    {
        if (other.tag == "Structure" )
        {
            Destroy(gameObject);
        }
    }
}
