using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour {

	public GameObject northB;
	public GameObject southB;
	public GameObject eastB;
	public GameObject westB;
	public GameObject stone1;
	public GameObject stone2;
	private bool twoStone = false;
	private string order = "EWNS";
	private string burned = "";
	private bool fourBars = false;

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

		if (fourBars && twoStone) {
			this.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y, -4);
		}

	}
}
