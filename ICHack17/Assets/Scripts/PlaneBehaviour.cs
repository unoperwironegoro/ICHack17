using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlaneBehaviour : NetworkBehaviour {

    public float maxSpeed = 5f;
    public float deceleration = 0.3f;
    public float tightness = 100;
    private Rigidbody2D rb2d;
    public GameObject mouse { set; private get; }
    public GameObject bulletPrefab;
    private bool hasFired = false;

    // Use this for initialization
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (mouse.GetComponent<MouseController>().isDown)
        {
            if (!hasFired)
            {
                GameObject bulletObj = Instantiate(bulletPrefab, rb2d.transform.position, Quaternion.Euler(0, 0, 0));
                NetworkServer.Spawn(bulletObj);
                bulletObj.GetComponent<Rigidbody2D>().velocity = rb2d.velocity.normalized * 5;
                bulletObj.GetComponent<bulletBehaviour>().owner = gameObject;
                bulletObj.GetComponent<SpriteRenderer>().color = gameObject.GetComponent<SpriteRenderer>().color;
                hasFired = true;
            }
        }
        else
        {
            hasFired = false;
        }
    }

    void FixedUpdate()
    {
        if (!isServer)
        {
            return;
        }

        var mouseVec = mouse.transform.position;

        var moveVec = mouseVec - transform.position;

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
        if(!isServer) {
            return;
        }

        if (collision.gameObject.GetComponent<bulletBehaviour>().owner == gameObject)
        {
            return;
        }
        NetworkServer.Destroy(gameObject);
    }

    [SyncVar(hook = "OnColorChanged")]
    Color myColor;

    void OnColorChanged(Color value)
    {
        myColor = value;
        GetComponent<SpriteRenderer>().color = myColor;
    }
}
