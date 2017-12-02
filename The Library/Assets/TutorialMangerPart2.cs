using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialMangerPart2 : MonoBehaviour {

    public Text tutorialText;
    public SteamVR_TrackedController _controller1;
    public SteamVR_TrackedController _controller2;
    private bool gripped = false;

    // Use this for initialization

    private void OnEnable()
    {
        _controller1.Gripped += HandleRightGripClicked;
        _controller2.Gripped += HandleRightGripClicked;
    }

    private void HandleLeftGripClicked(object sender, ClickedEventArgs e)
    {
        if(!gripped)
        {
            tutorialText.text = "Riddle text";
            gripped = true;
        }
    }

    private void HandleRightGripClicked(object sender, ClickedEventArgs e)
    {
        if (!gripped)
        {
            tutorialText.text = "Riddle text";
            gripped = true;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
