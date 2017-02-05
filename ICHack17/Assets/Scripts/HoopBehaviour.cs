using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoopBehaviour : MonoBehaviour {

    private int redCount;
    private int greenCount;
    private int blueCount;
    private int orangeCount;

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter (Collider other) {
        string tag = other.tag;
        switch (tag) {
            case "Red":
                redCount++; break;
            case "Green":
                greenCount++; break;
            case "Orange":
                orangeCount++; break;
            case "Blue":
                blueCount++; break;            
        }
        
    }
}
