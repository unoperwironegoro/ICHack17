using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class HoopBehaviour : MonoBehaviour {

    private int redCount = 0;
    private int greenCount = 0;
    private int blueCount = 0;
    private int orangeCount = 0;

    public Text scoreDisplay;

    // Use this for initialization
    void Start () {
        setDisplay ();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D obj) {

        if (obj.gameObject.CompareTag("Red")) {
            redCount++;
        } else if (obj.gameObject.CompareTag("Green")) {
            greenCount++;
        } else if (obj.gameObject.CompareTag("Orange")) {
            orangeCount++;
        } else { 
            blueCount++; 
        }
        setDisplay();
        
    }

    void setDisplay () {
        scoreDisplay.text = "Red:" + redCount.ToString() +
                           " Blue: " + blueCount.ToString() +
                           " Green: " + greenCount.ToString() +
                           " Orange: " + orangeCount.ToString();
    }
}
