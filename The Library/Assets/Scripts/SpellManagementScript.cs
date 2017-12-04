using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class SpellManagementScript : MonoBehaviour {

    public GameObject currentSpell;
    public GameObject laserPrefab;

    private bool combinedModeEntered = false;
    private SteamVR_TrackedController _controller;
    private GameObject laser;
    private Transform laserTransform;
    private Vector3 hitPoint;
    private bool laserActive = false;

    void Start()
    {
        laser = Instantiate(laserPrefab);
        laserTransform = laser.transform;
    }

    private void OnEnable()
    {
        _controller = GetComponent<SteamVR_TrackedController>();
        _controller.TriggerClicked += HandleTriggerClicked;
        _controller.PadClicked += HandlePadClicked;
    }

    private void OnDisable()
    {
        _controller.TriggerClicked -= HandleTriggerClicked;
        _controller.PadClicked -= HandlePadClicked;
    }

    private void HandleTriggerClicked(object sender, ClickedEventArgs e)
    {
        SpawnCurrentSpellAtController();
    }

    private void HandlePadClicked(object sender, ClickedEventArgs e)
    {
        if(!laserActive)
        {
            laserActive = true;
        }
        else
        {
            laserActive = false;
        }
    }

    private void ShowLaser(RaycastHit hit)
    {
        // 1
        laser.SetActive(true);
        // 2
        laserTransform.position = Vector3.Lerp(_controller.transform.position, hitPoint, .5f);
        // 3
        laserTransform.LookAt(hitPoint);
        // 4
        laserTransform.localScale = new Vector3(laserTransform.localScale.x, laserTransform.localScale.y,
            hit.distance);

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
		GameObject animation = GameObject.Instantiate(currentSpell.transform.GetChild(0).gameObject, _controller.transform.position, _controller.transform.rotation, spell.transform);
        spell.GetComponent<Projectile>().direction = dir;
    }

    public void setCombinedMode(bool var)
    {
        combinedModeEntered = var;
    }

    void Update()
    {
        if (laserActive)
        {
            RaycastHit hit;

            // 2
            if (Physics.Raycast(_controller.transform.position, transform.forward, out hit, 300))
            {
                hitPoint = hit.point;
                ShowLaser(hit);
            }
        }
        else
        {
            laser.SetActive(false);
        }
    }
}
