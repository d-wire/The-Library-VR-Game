using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour {

    public Text tutorialText;
    public SteamVR_TrackedController _controller1;
    public SteamVR_TrackedController _controller2;

    private bool spellSet = false;
    private bool spellCast = false;
    private bool laserEnabled = false;

    // Use this for initialization

    private void OnEnable()
    {
       // _controller1 = GetComponent<SteamVR_TrackedController>();
        _controller1.TriggerClicked += HandleTriggerClicked;
        _controller1.PadClicked += HandlePadClicked;

       // _controller2 = GetComponent<SteamVR_TrackedController>();
        _controller2.TriggerClicked += HandleTriggerClicked;
        _controller2.PadClicked += HandlePadClicked;
    }

    private void HandleTriggerClicked(object sender, ClickedEventArgs e)
    {
        if (spellSet)
        {
            tutorialText.text = "You can also toggle a \r\n laser pointer for aiming \r\n by clicking the touchpad.";
            spellCast = true;
        }
    }

    private void HandlePadClicked(object sender, ClickedEventArgs e)
    {
        if (spellCast)
        {
            tutorialText.text = "Riddle text.";
            laserEnabled = true;
        }
    }

    // Update is called once per frame
    void Update () {
        if ((_controller1.GetComponent<SpellManagementScript>().currentSpell != null || _controller2.GetComponent<SpellManagementScript>().currentSpell != null) && !spellSet)
        {
            tutorialText.text = "Now pull the trigger of the\r\n controller with the \r\n equipped spell to cast the spell.";
            spellSet = true;
        }
        {

        }
	}
}
