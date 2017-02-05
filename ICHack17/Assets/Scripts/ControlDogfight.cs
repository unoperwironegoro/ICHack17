using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ControlDogfight : NetworkBehaviour {

    public GameObject planePrefab;
    private Vector3 startPos = new Vector3(0, 0, 0);

    void Awake()
    {
        if (isLocalPlayer)
        {
            return;
        }

        // Create Racers
        var mouseArray = GameObject.FindGameObjectsWithTag("Mouse");

        int i = 0;
        foreach (GameObject g in mouseArray)
        {
            GameObject planeObj = Instantiate(planePrefab, startPos + new Vector3(i * 3, 0, 0), Quaternion.Euler(0, 0, 0));
            planeObj.GetComponent<PlaneBehaviour>().mouse = g;
            planeObj.GetComponent<SpriteRenderer>().color = g.GetComponent<MouseController>().colour;
            NetworkServer.Spawn(planeObj);
            i++;
        }
    }
}
