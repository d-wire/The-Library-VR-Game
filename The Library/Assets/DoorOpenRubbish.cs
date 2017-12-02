using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
	
	// Update is called once per frame
	void Update () {
		if(!crate1.activeInHierarchy && !crate2.activeInHierarchy && !crate3.activeInHierarchy && !crate4.activeInHierarchy && !crate5.activeInHierarchy && !crate6.activeInHierarchy &&
            !barrel1.activeInHierarchy && !barrel2.activeInHierarchy && !barrel3.activeInHierarchy && !barrel4.activeInHierarchy && !barrel5.activeInHierarchy)
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, -4);
            StartCoroutine(LoadNextWithDelay());
        }
	}

    IEnumerator LoadNextWithDelay()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Combination");
    }
}
