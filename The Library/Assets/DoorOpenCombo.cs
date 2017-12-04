using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DoorOpenCombo : MonoBehaviour {

	public GameObject turbine;
	public GameObject switch1;
	public GameObject wallthing;
	public GameObject growTree;
	public GameObject blankPlane;
	public GameObject levelText;
	private bool turnt = false;
	private bool switched = false;
    private bool test = false;
    private bool doored = false;
    private bool test2 = false;

	private float t1 = 0;
	private float t2 = 0;
	private float duration = 3f;
	private Color32 blackPlane = new Color32 (0, 0, 0, 255);
	private Color32 clearPlane = new Color32 (0, 0, 0, 0);
	private Color32 whiteText = new Color32 (255, 255, 255, 255);
	private bool levelOver = false;

	// Start up operations
	void Start () {
		levelText = GameObject.Find("LevelText");
		levelText.GetComponent<Text> ().text = "The Courtyard";
		blankPlane = GameObject.Find("BlankPlane");
		blankPlane.GetComponent<Image>().color = blackPlane;
	}

    // Update is called once per frame
    void Update () {
		if (turbine.CompareTag ("Steamed") && !turnt) {
            //wallthing.SetActive (false);
            StartCoroutine(LerpScale2(5f));
			turnt = true;
		}
		if (turnt) {
			turbine.transform.Rotate (0,0,50*Time.deltaTime);
		}
		if (turnt && growTree.CompareTag ("Watered") && !switched) {
            //Vector3 size = growTree.transform.localScale;
            //size += new Vector3(0f, 1f, 0f);
            //growTree.transform.localScale = Vector3.Lerp(size, growTree.transform.localScale, 1f);
            StartCoroutine(LerpScale(3f));
        }
        if(test && !test2)
        {
            StartCoroutine(LerpRotate(1.5f));
        }
		if (switched && test && !doored){
			StartCoroutine (LerpDoor (3f));
			levelOver = true;
		}

		blankPlane.GetComponent<Image>().color = Color.Lerp (blackPlane, clearPlane, t1);
		levelText.GetComponent<Text>().color = Color.Lerp (whiteText, clearPlane, t1);
		if (t1 < 1) {
			t1 += Time.deltaTime / duration;
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

	IEnumerator LoadNextWithDelay() {
		yield return new WaitForSeconds(7);
		SceneManager.LoadScene ("Library");
	}


    IEnumerator LerpScale(float time)
    {
        switched = true;
        Vector3 originalScale = growTree.transform.localScale;
        Vector3 targetScale = originalScale + new Vector3(0f, 1f, 0f);
        float originalTime = time;

        while (time > 0.0f)
        {
            time -= Time.deltaTime;

            if(time / originalTime <= 0.5f && !test)
            {
                test = true;
            }

            growTree.transform.localScale = Vector3.Lerp(targetScale, originalScale, time / originalTime);
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator LerpScale2(float time)
    {
        Vector3 originalPosition = wallthing.transform.position;
        Vector3 targetPosition = originalPosition + new Vector3(45f, 0f, 0f);
        float originalTime = time;

        while (time > 0.0f)
        {
            time -= Time.deltaTime;

            wallthing.transform.position = Vector3.Lerp(targetPosition, originalPosition, time / originalTime);
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator LerpRotate(float time)
    {
        test2 = true;
        Vector3 originalAngle = switch1.transform.eulerAngles;
        Vector3 targetScale = originalAngle + new Vector3(0f, 0f, -60f);
        float originalTime = time;

        while (time > 0.0f)
        {
            time -= Time.deltaTime;

            switch1.transform.eulerAngles = Vector3.Lerp(targetScale, originalAngle, time / originalTime);
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator LerpDoor(float time)
	{
		Vector3 originalPosition = this.transform.position;
		Vector3 targetPosition = originalPosition + new Vector3(0f, 0f, -4f);
		float originalTime = time;
        doored = true;

		while (time > 0.0f)
		{
			time -= Time.deltaTime;

			this.transform.position = Vector3.Lerp(targetPosition, originalPosition, time / originalTime);
			yield return new WaitForEndOfFrame();
		}
	}

}
