using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorOpenCombo : MonoBehaviour {

	public GameObject turbine;
	public GameObject switch1;
	public GameObject switch2;
	public GameObject wallthing;
	public GameObject growTree;
	private bool turnt = false;
	private bool switched = false;

	// Update is called once per frame
	void Update () {
		if (turbine.CompareTag ("Steamed")) {
			wallthing.SetActive (false);
			turnt = true;
		}
		if (turnt && growTree.CompareTag ("Watered")) {
			growTree.gameObject.transform.localScale.Set (.75f, 1.25f, .75f);
			switch1.SetActive (false);
			switch2.SetActive (true);
			switched = true;
		}
		if (switched){
			this.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y, -4);
			StartCoroutine (LoadNextWithDelay ());
		}

	}

	IEnumerator LoadNextWithDelay() {
		yield return new WaitForSeconds(3);
		SceneManager.LoadScene ("Library");
	}
}
