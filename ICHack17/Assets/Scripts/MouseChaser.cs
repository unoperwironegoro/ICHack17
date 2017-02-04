using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseChaser : MonoBehaviour {

   
    public float maxSpeed = 5f;
    public float deceleration = 0.3f;
    public float tightness = 100;
    private Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        var mouseVec = Input.mousePosition;
        mouseVec.z = 10.0f;
        mouseVec = Camera.main.ScreenToWorldPoint(mouseVec);

        var moveVec = mouseVec - transform.position;

        /* Old method which could be reused for following with a delay */
        /* Updates the speed based on distance to the pointer
        if (moveVec.magnitude > 2f)
        {
            if (curSpeed < maxSpeed)
            {
                curSpeed = curSpeed + acceleration;
            }
        }
        else if (moveVec.magnitude > 0.05f)
        {
            if (curSpeed - acceleration > 0)
              curSpeed = curSpeed - acceleration;
        }
        else
        {
            curSpeed = 0;
        }
        */
        //  transform.position = (moveVec.normalized * curSpeed) + transform.position;

        /* If the object is far then apply a force */
        if (moveVec.magnitude > 1)
        {
            rb2d.AddForce(moveVec.normalized * tightness);
            /* Apply a strong force and then cap the maximum speed */
            if (rb2d.velocity.magnitude > maxSpeed)
            {
                rb2d.velocity = rb2d.velocity.normalized * maxSpeed;
            }
        }
        else
        {
            /* If the object is close to the pointer then slow to a halt */
            if (rb2d.velocity.magnitude - deceleration > 0)
            {
                rb2d.velocity = (rb2d.velocity.magnitude - deceleration) * rb2d.velocity.normalized;
            }
            else
            {
                rb2d.velocity = Vector2.zero;
            }
        }
    }
}
