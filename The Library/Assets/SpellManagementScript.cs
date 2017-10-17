using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellManagementScript : MonoBehaviour {
    
    public GameObject[] Prefabs;

    private GameObject currentPrefabObject;
    private int currentPrefabIndex;

    private void UpdateEffect()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCurrent();
        }
        else if (Input.GetKeyDown(KeyCode.Plus) || Input.GetKeyDown(KeyCode.KeypadPlus))
        {
            NextPrefab();
        }
        else if (Input.GetKeyDown(KeyCode.Minus) || Input.GetKeyDown(KeyCode.KeypadMinus))
        {
            PreviousPrefab();
        }
    }

    void BeginEffect() {
        currentPrefabObject = GameObject.Instantiate(Prefabs[currentPrefabIndex]);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        UpdateEffect();
	}

    public void StartCurrent()
    {
        StopCurrent();
        BeginEffect();
    }
    public void StopCurrent()
    {
        currentPrefabObject = null;
    }

    public void NextPrefab()
    {
        currentPrefabIndex++;
        if (currentPrefabIndex == Prefabs.Length)
        {
            currentPrefabIndex = 0;
        }
    }

    public void PreviousPrefab()
    {
        currentPrefabIndex--;
        if (currentPrefabIndex == -1)
        {
            currentPrefabIndex = Prefabs.Length - 1;
        }
    }
}
