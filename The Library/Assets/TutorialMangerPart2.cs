using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialMangerPart2 : MonoBehaviour {

    public Text tutorialText;
    public SteamVR_TrackedController _controller1;
    public SteamVR_TrackedController _controller2;

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

    }

    private void HandlePadClicked(object sender, ClickedEventArgs e)
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
