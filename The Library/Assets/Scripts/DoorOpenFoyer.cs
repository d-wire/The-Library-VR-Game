using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorOpenFoyer : MonoBehaviour {

	public GameObject water;
	public GameObject bucket;
	public GameObject bucketCollider;
	private bool filled = false;
	private bool scored = false;

	// Update is called once per frame
	void Update () {
		if (water.CompareTag ("Watered")) {
			water.GetComponent<MeshRenderer> ().enabled = true;
			filled = true;
		}
		if (filled && water.CompareTag("Zapped")) {
			bucket.SetActive (true);
			bucketCollider.SetActive (true);
		}
		if (bucketCollider.GetComponent<MeshRenderer>().enabled && !scored) {
			scored = true;
			StartCoroutine (LerpDoor (3f));
			//StartCoroutine (LoadNextWithDelay ());
		}
	}

	IEnumerator LoadNextWithDelay() {
		yield return new WaitForSeconds(7);
		SceneManager.LoadScene ("Library");
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
}
