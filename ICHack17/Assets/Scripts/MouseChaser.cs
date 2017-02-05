using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MouseChaser : NetworkBehaviour {
   
    public float maxSpeed = 5f;
    public float deceleration = 0.3f;
    public float tightness = 100;
    private Rigidbody2D rb2d;
    public float sleepTime;
    public Transform mouse { set; private get; }

    /* car things */
    private int lap = 0;
    private static int WIN_LAPS = 2;
    bool canLap = true;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if(!isServer) {
            return;
        }

        var mouseVec = mouse.position;

        var moveVec = mouseVec - transform.position;

        if (sleepTime > 0)
        {
            sleepTime -= Time.fixedDeltaTime;
            float angle = Mathf.Atan2(moveVec.y, moveVec.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
            return;
        }

        /* If the object is far then apply a force */
        if (moveVec.magnitude > 1)
        {
            rb2d.AddForce(moveVec.normalized * tightness);
            /* Apply a strong force and then cap the maximum speed */
            if (rb2d.velocity.magnitude > maxSpeed)
            {
                rb2d.velocity = rb2d.velocity.normalized * maxSpeed;
            }
            float angle = Mathf.Atan2(moveVec.y, moveVec.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
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
            float angle = Mathf.Atan2(moveVec.y, moveVec.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
        }
    }
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (sleepTime > 0 && (collision.gameObject.layer == LayerMask.NameToLayer("Car" )))
        {
            return;
        }
        rb2d.AddForce(rb2d.velocity * -100);
        sleepTime = 1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (rb2d.velocity.x > 0)
        {
            if (canLap)
            {
                if  (lap >= WIN_LAPS)
                {
                    Debug.Log("ayyyyyyy");
                }
            }
           
            lap++;
            canLap = true;
        }
        else
        {
            canLap = false;
        }
       
    }
}
