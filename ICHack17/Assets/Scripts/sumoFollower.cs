using UnityEngine;
using UnityEngine.Networking;

public class sumoFollower : NetworkBehaviour {

    public float speed;

    public override void OnStartLocalPlayer()
    {
     /*   Color color = Random.ColorHSV();
        color.a = 1f;

        GetComponent<SpriteRenderer>().color = color;
        CmdSetColor(color); 
        */
    }

    [Command]
    void CmdSetColor(Color color)
    {
        GetComponent<SpriteRenderer>().color = color;
    }

    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }

        float step = speed * Time.deltaTime;

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10.0f;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        Vector3 playerPos = transform.position;

        if (Vector3.Distance(mousePos, playerPos) < 2)
        {
            step /= 2;
        }

        transform.position = Vector3.MoveTowards(playerPos, mousePos, step);
    }
}
