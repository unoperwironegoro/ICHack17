using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ControlRace : NetworkBehaviour {

    private GameObject[] mouseArray;
    GameObject carPrefab;
    private Vector3 startPos = new Vector3(0, 0, 0);
	// Use this for initialization
	void Start () {
        mouseArray = GameObject.FindGameObjectsWithTag("Mouse");
        createRacers();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void createRacers()
    {
        int i = 0;
        foreach (GameObject g in mouseArray)
        {
            GameObject carObj = Instantiate(carPrefab, startPos + new Vector3(i * 50, 0, 0) , Quaternion.Euler(0, 0, 0));
            carObj.GetComponent<MouseChaser>().mouse = g;
            NetworkServer.Spawn(carObj);
            i++;
        }
    }
}
