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
		if (turbine.CompareTag ("Steamed") && !turnt) {
            //wallthing.SetActive (false);
            StartCoroutine(LerpScale2(5f));
			turnt = true;
		}
		if (turnt && growTree.CompareTag ("Watered") && !switched) {
            //Vector3 size = growTree.transform.localScale;
            //size += new Vector3(0f, 1f, 0f);
            //growTree.transform.localScale = Vector3.Lerp(size, growTree.transform.localScale, 1f);
            StartCoroutine(LerpScale(3f));
            
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
		SceneManager.LoadScene ("Foyer");
	}

    IEnumerator LerpScale(float time)
    {
        Vector3 originalScale = growTree.transform.localScale;
        Vector3 targetScale = originalScale + new Vector3(0f, 1f, 0f);
        float originalTime = time;

        while (time > 0.0f)
        {
            time -= Time.deltaTime;

            growTree.transform.localScale = Vector3.Lerp(targetScale, originalScale, time / originalTime);
            yield return new WaitForEndOfFrame();
        } 
    }

    IEnumerator LerpScale2(float time)
    {
        Vector3 originalPosition = wallthing.transform.position;
        Vector3 targetPosition = originalPosition + new Vector3(22f, 0f, 0f);
        float originalTime = time;

        while (time > 0.0f)
        {
            time -= Time.deltaTime;

            wallthing.transform.position = Vector3.Lerp(targetPosition, originalPosition, time / originalTime);
            yield return new WaitForEndOfFrame();
        }
    }
}
