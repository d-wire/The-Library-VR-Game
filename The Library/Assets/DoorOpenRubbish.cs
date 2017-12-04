using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DoorOpenRubbish : MonoBehaviour {

    public GameObject crate1;
    public GameObject crate2;
    public GameObject crate3;
    public GameObject crate4;
    public GameObject crate5;
    public GameObject crate6;

    public GameObject barrel1;
    public GameObject barrel2;
    public GameObject barrel3;
    public GameObject barrel4;
    public GameObject barrel5;
	public GameObject blankPlane;
	public GameObject levelText;
	private bool done = false;

	private float t1 = 0;
	private float t2 = 0;
	private float t3 = 0;
	private float openingDuration = 10f;
	private float duration = 3f;
	private Color32 blackPlane = new Color32 (0, 0, 0, 255);
	private Color32 clearPlane = new Color32 (0, 0, 0, 0);
	private Color32 whiteText = new Color32 (255, 255, 255, 255);
	private bool levelOver = false;
	private bool openingOver = false;

	// Start up operations
	void Start () {
		levelText = GameObject.Find("LevelText");
		levelText.GetComponent<Text> ().text = "The Rubbish Room";
		blankPlane = GameObject.Find("BlankPlane");
		blankPlane.GetComponent<Image>().color = blackPlane;
	}

	// Update is called once per frame
	void Update () {
		if(!crate1.activeInHierarchy && !crate2.activeInHierarchy && !crate3.activeInHierarchy && !crate4.activeInHierarchy && !crate5.activeInHierarchy && !crate6.activeInHierarchy &&
            !barrel1.activeInHierarchy && !barrel2.activeInHierarchy && !barrel3.activeInHierarchy && !barrel4.activeInHierarchy && !barrel5.activeInHierarchy && !done)
        {
			done = true;
			StartCoroutine (LerpDoor (3f));
			levelOver = true;
        }

		if (openingOver) {
			blankPlane.GetComponent<Image> ().color = Color.Lerp (blackPlane, clearPlane, t3);
			levelText.GetComponent<Text> ().color = Color.Lerp (whiteText, clearPlane, t3);
			if (t3 < 1) {
				t3 += Time.deltaTime / duration;
			} 
		} else {
			levelText.GetComponent<Text> ().text = "The Library";
			levelText.GetComponent<Text> ().color = Color.Lerp (whiteText, clearPlane, t1);
			if (t1 < 1) {
				t1 += Time.deltaTime / duration;
			} else {
				openingOver = true;
				levelText.GetComponent<Text> ().text = "The Rubbish Room";
				blankPlane.GetComponent<Image>().color = blackPlane;
			}
		}

		if (levelOver) {
			blankPlane.GetComponent<Image>().color = Color.Lerp (clearPlane, blackPlane, t2);
			if (t2 < 1) {
				t2 += Time.deltaTime / duration;
			} else {
				StartCoroutine (LoadNextWithDelay ());
			}

		}
	}


	IEnumerator LerpDoor(float time)
	{
		Vector3 originalPosition = this.transform.position;
		Vector3 targetPosition = originalPosition + new Vector3(0f, 0f, -4f);
		float originalTime = time;

		while (time > 0.0f)
		{
			time -= Time.deltaTime;

			this.transform.position = Vector3.Lerp(targetPosition, originalPosition, time / originalTime);
			yield return new WaitForEndOfFrame();
		}
	}

    IEnumerator LoadNextWithDelay()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Combination");
    }
}
