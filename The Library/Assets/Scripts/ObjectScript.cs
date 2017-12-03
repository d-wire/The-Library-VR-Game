using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScript : MonoBehaviour {

	public bool burnable; // can be destroyed by fire-spell
	public bool movable; // can be moved by air-spell
	public bool fillable; // can be filled by water-spell
	public bool steamable;
    public bool zappable;
    public bool scorable;

	private Rigidbody rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Burn(){
		// destroy object with burn spell
		Destroy (gameObject);
	}

	public void Push(Vector3 delta) {
        //move object, need to pass in a direction
        transform.position += delta;
	}

	public void Steam(){
	
	}


}
