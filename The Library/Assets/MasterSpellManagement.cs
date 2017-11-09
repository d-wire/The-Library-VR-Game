using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MasterSpellManagement : MonoBehaviour {

    public SteamVR_TrackedController left_controller;
    public SteamVR_TrackedController right_controller;
    public GameObject[] combinedSpells;
    public Dictionary<string, GameObject> spellMapping = new Dictionary<string, GameObject>();

    private void OnEnable()
    {
        left_controller.Gripped += HandleLeftGripClicked;
        right_controller.Gripped += HandleRightGripClicked;
    }

        // Use this for initialization
    void Start () {
        string steamKey = "FireSpell, WaterSpell";
        spellMapping.Add(steamKey, combinedSpells[0]);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void HandleLeftGripClicked(object sender, ClickedEventArgs e)
    {
       CombineSpells(0);
    }

    private void HandleRightGripClicked(object sender, ClickedEventArgs e)
    {
        CombineSpells(1);
    }

    void CombineSpells(int val)
    {
        string[] spells = new string[] { left_controller.gameObject.GetComponent<SpellManagementScript>().currentSpell.name, right_controller.gameObject.GetComponent<SpellManagementScript>().currentSpell.name };
        Array.Sort(spells);
        string key = spells[0] + ", " + spells[1];
        if(spellMapping.ContainsKey(key))
        {
            if(val == 0)
            {
                left_controller.gameObject.GetComponent<SpellManagementScript>().setCombinedMode(true);
                left_controller.gameObject.GetComponent<SpellManagementScript>().currentSpell = spellMapping[key];
            }
            if (val == 1)
            {
                right_controller.gameObject.GetComponent<SpellManagementScript>().setCombinedMode(true);
                right_controller.gameObject.GetComponent<SpellManagementScript>().currentSpell = spellMapping[key];
            }
        }
    }
}
