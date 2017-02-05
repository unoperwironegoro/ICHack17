using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketballBehaviour : MonoBehaviour {

    private Vector3 screenPoint;
    Vector3 startPosition;
    private Rigidbody2D rb2d;
    private bool isDown = false;
    public GameObject mouse { set; private get; }


    // Use this for initialization
    void Start() {
        rb2d = GetComponent<Rigidbody2D>();                
    }

   
    private Vector3 offset;

    void OnMouseDown()
    {
        startPosition = Input.mousePosition;
        offset = gameObject.transform.position -
            Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
    }

    void OnMouseDrag()
    {
        Vector3 newPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f);
        transform.position = Camera.main.ScreenToWorldPoint(newPosition) + offset;
    }

    void OnMouseUp()
    {
        Vector3 newPosition = mouse.transform.position;
        // The times 5 is to make the force stronger.
        GetComponent<Rigidbody2D>().AddForce((newPosition - startPosition) * 5,
            ForceMode2D.Force);

    }

}

