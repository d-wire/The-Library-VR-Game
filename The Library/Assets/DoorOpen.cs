using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DoorOpen : MonoBehaviour {

	public GameObject northB;
	public GameObject southB;
	public GameObject eastB;
	public GameObject westB;
	public GameObject stone1;
	public GameObject stone2;
	public GameObject bridge;
	public GameObject blankPlane;
	public GameObject levelText;
	private bool twoStone = false;
	private string order = "EWNS";
	private string burned = "";
	private bool fourBars = false;
	private bool done = false;
	private bool openDoor = false;
	private bool done2 = false;

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
		levelText.GetComponent<Text> ().text = "The Entrance Hall";
		blankPlane = GameObject.Find("BlankPlane");
		blankPlane.GetComponent<Image>().color = blackPlane;
	}

	// Update is called once per frame
	void Update () {
		if (stone1.GetComponent<MeshRenderer> ().enabled && stone2.GetComponent<MeshRenderer> ().enabled) {
			twoStone = true;
		}

		if (!northB.activeSelf && !burned.Contains ("N")) {
			burned += "N";
		}
		if (!southB.activeSelf && !burned.Contains ("S")) {
			burned += "S";
		}
		if (!eastB.activeSelf && !burned.Contains ("E")) {
			burned += "E";
		}
		if (!westB.activeSelf && !burned.Contains ("W")) {
			burned += "W";
		}
			
		if (burned.Length == 4 && burned.Equals (order)) {
			fourBars = true;
		} 
		else if (burned.Length == 4){
			northB.SetActive (true);
			southB.SetActive (true);
			eastB.SetActive (true);
			westB.SetActive (true);
			burned = "";
		}

		if (fourBars && twoStone && !done) {
			done = true;
			StartCoroutine (LerpBridge (5f));
		}

		if (done && openDoor && !done2) {
			done2 = true;
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

		if (northB.transform.position.y < -10 || southB.transform.position.y < -10 || eastB.transform.position.y < -10 || westB.transform.position.y < -10) {
			SceneManager.LoadScene ("Library");
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

	IEnumerator LerpBridge(float time) {
		Vector3 originalPosition = bridge.transform.position;
		Vector3 targetPosition = originalPosition + new Vector3 (71.9f, 0f, 0f);
		float originalTime = time;

		while (time > 0.0f)
		{
			time -= Time.deltaTime;

			bridge.transform.position = Vector3.Lerp(targetPosition, originalPosition, time / originalTime);
			yield return new WaitForEndOfFrame();
		}
		openDoor = true;
	}

	IEnumerator LoadNextWithDelay() {
		yield return new WaitForSeconds(3);
		SceneManager.LoadScene ("Foyer");
	}
}
