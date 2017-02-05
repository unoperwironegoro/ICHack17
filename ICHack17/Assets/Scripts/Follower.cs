using UnityEngine;
using UnityEngine.Networking;

public class Follower : NetworkBehaviour {

    public float speed;
    public Transform mouse { set; private get; }

    /* private void OnTriggerEnter2D(Collider2D collision)
     {

         if (collision.gameObject.CompareTag("Player"))
         {
             collision.gameObject.SetActive(false);
         }
     } */

    void Update()
    {
        if (!isServer)
        {
            return;
        }

        float step = speed * Time.deltaTime;

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10.0f;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        if (mousePos.x < 0)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        } else
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }

        Vector3 playerPos = transform.position;

        if (Vector3.Distance(mousePos, playerPos) < 2)
        {
            step /= 2;
        }

        transform.position = Vector3.MoveTowards(playerPos, mousePos, step);
    }
}
