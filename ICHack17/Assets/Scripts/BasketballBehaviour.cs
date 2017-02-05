using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketballBehaviour : MonoBehaviour {

    private Vector3 screenPoint;
    Vector3 startPosition;

    // Use this for initialization
    void Start() {
                
    }

    // Update is called once per frame
    void Update() { 
    }

    private void OnMouseDown() {
        startPosition = Input.mousePosition;
        screenPoint = Camera.main.WorldToScreenPoint(transform.position);

    }

    private void OnMouseDrag() {
        Vector3 curScreenPoint = 
            new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint);
        transform.position = curPosition;
    }

    private void OnMouseUp() {
        Vector3 newPosition = Input.mousePosition;
        GetComponent<Rigidbody2D>().AddForce((newPosition - startPosition)*5,
            ForceMode2D.Force);
    }

}
