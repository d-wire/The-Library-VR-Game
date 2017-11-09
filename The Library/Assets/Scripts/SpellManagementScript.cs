using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class SpellManagementScript : MonoBehaviour {
    
    public GameObject currentSpell;

    private bool combinedModeEntered = false;
    private SteamVR_TrackedController _controller;

    private void OnEnable()
    {
        _controller = GetComponent<SteamVR_TrackedController>();
        _controller.TriggerClicked += HandleTriggerClicked;
    }

    private void OnDisable()
    {
        _controller.TriggerClicked -= HandleTriggerClicked;
    }

    private void HandleTriggerClicked(object sender, ClickedEventArgs e)
    {
        SpawnCurrentSpellAtController();
    }

    private void SpawnCurrentSpellAtController()
    {
        if(combinedModeEntered)
        {
            CastSpell();
            combinedModeEntered = false;
            currentSpell = null;
        }
        else
        {
            CastSpell();
            currentSpell = null;
        }
    }

    void CastSpell()
    {
        if(currentSpell == null)
        {
            return;
        }
        Vector3 dir = _controller.transform.eulerAngles;
        GameObject spell = GameObject.Instantiate(currentSpell, _controller.transform.position, _controller.transform.rotation);
        spell.GetComponent<Projectile>().direction = dir;
    }

    public void setCombinedMode(bool var)
    {
        combinedModeEntered = var;
    }
}
