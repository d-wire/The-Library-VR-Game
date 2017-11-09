using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCurrentSpell : MonoBehaviour {

    public GameObject spell;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("collided");
        if (other.tag == "GameController")
        {
            other.gameObject.GetComponent<SpellManagementScript>().currentSpell = spell;
        }
    }
}
