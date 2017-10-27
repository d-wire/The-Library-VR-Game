using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class SpellManagementScript : MonoBehaviour {
    
    public GameObject[] Prefabs;
    public Dictionary<string, GameObject> combinedSpells = new Dictionary<string, GameObject>();

    private GameObject currentPrefabObject;
    private GameObject combinedEffect;
    private int currentPrefabIndexRight;
    private int currentPrefabIndexLeft;
    private bool combinedModeEntered = false;
    

    private void UpdateEffect()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCurrentLeft();
        }
        else if (Input.GetMouseButtonDown(1))
        {
            StartCurrentRight();
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            NextPrefabRight();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            PreviousPrefabRight();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            NextPrefabLeft();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            PreviousPrefabLeft();
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            CombineEffects(currentPrefabIndexLeft, currentPrefabIndexRight);
        }
    }

    void Start()
    {
        // Temporary proof of concept
        string[] testSpells = new string[] { Prefabs[0].name, Prefabs[1].name };
        Array.Sort(testSpells);
        string key = testSpells[0] + ", " + testSpells[1];
        combinedSpells.Add(key, Prefabs[2]);
    }

    // Update is called once per frame
    void Update () {
        UpdateEffect();
	}

    public void StartCurrentRight()
    {
        StopCurrent();
        Vector3 right_pos = new Vector3(transform.position.x - 10, transform.position.y, transform.position.z);
        currentPrefabObject = GameObject.Instantiate(Prefabs[currentPrefabIndexRight]);
        //currentPrefabObject.transform.TransformDirection(right_pos);
    }
    public void StartCurrentLeft()
    {
        StopCurrent();
        if (combinedModeEntered)
        {
            currentPrefabObject = GameObject.Instantiate(combinedEffect);
            combinedModeEntered = false;
        }
        else
        {
            currentPrefabObject = GameObject.Instantiate(Prefabs[currentPrefabIndexLeft]);
        }
    }
    public void StopCurrent()
    {
        currentPrefabObject = null;
    }

    public void NextPrefabRight()
    {
        currentPrefabIndexRight++;
        if (currentPrefabIndexRight >= Prefabs.Length-2)
        {
            currentPrefabIndexRight = 0;
        }
    }

    public void PreviousPrefabRight()
    {
        currentPrefabIndexRight--;
        if (currentPrefabIndexRight <= -1)
        {
            currentPrefabIndexRight = Prefabs.Length - 2;
        }
    }

    public void NextPrefabLeft()
    {
        currentPrefabIndexLeft++;
        if (currentPrefabIndexLeft >= Prefabs.Length-2)
        {
            currentPrefabIndexLeft = 0;
        }
    }

    public void PreviousPrefabLeft()
    {
        currentPrefabIndexLeft--;
        if (currentPrefabIndexLeft <= -1)
        {
            currentPrefabIndexLeft = Prefabs.Length - 2;
        }
    }

    public void CombineEffects(int index1, int index2)
    {
        string[] effects = new string[] { Prefabs[index1].name, Prefabs[index2].name };
        Array.Sort(effects);
        string key = effects[0] + ", " + effects[1];
        if (combinedSpells.ContainsKey(key))
        {
            combinedModeEntered = true;
            combinedEffect = combinedSpells[key];
        }
    }
}
