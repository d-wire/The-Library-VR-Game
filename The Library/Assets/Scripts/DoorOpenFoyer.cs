using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DoorOpenFoyer : MonoBehaviour {

	public GameObject water;
	public GameObject bucket;
	public GameObject bucketCollider;
	public GameObject blankPlane;
	public GameObject levelText;
	private bool filled = false;
	private bool scored = false;
	public GameObject particles;

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
		levelText.GetComponent<Text> ().text = "The Barren Bookshelves";
		blankPlane = GameObject.Find("BlankPlane");
		blankPlane.GetComponent<Image>().color = blackPlane;
	}

	// Update is called once per frame
	void Update () {
		if (water.CompareTag ("Watered")) {
			water.GetComponent<MeshRenderer> ().enabled = true;
			filled = true;
		}
		if (filled && water.CompareTag("Zapped")) {
			particles.SetActive (true);
			bucket.SetActive (true);
			bucketCollider.SetActive (true);
		}
		if (bucketCollider.GetComponent<MeshRenderer>().enabled && !scored) {
			scored = true;
			StartCoroutine (LerpDoor (3f));
			levelOver = true;
			//StartCoroutine (LoadNextWithDelay ());
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
				levelText.GetComponent<Text> ().color = whiteText;
				levelText.GetComponent<Text> ().text = "The End";
			}

		}
	}

	/*
	IEnumerator LoadNextWithDelay() {
		yield return new WaitForSeconds(7);
		SceneManager.LoadScene ("Library");
	}
	*/

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
}
