using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCollide : MonoBehaviour {

    Rigidbody2D rb2d;
    
	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        //rb2d.AddForce(rb2d.velocity * -1);
    }
}
