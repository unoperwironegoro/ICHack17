using UnityEngine;
using UnityEngine.Networking;

public class MouseFollower : NetworkBehaviour {

    public override void OnStartLocalPlayer() {
        Color color = Random.ColorHSV();
        color.a = 1f;

        GetComponent<SpriteRenderer>().color = color;
        CmdSetColor(color);
    }

    [Command]
    void CmdSetColor(Color color) {
        GetComponent<SpriteRenderer>().color = color;
    }

    void Update () {
        if (!isLocalPlayer) {
            return;
        }

        var v3 = Input.mousePosition;
        v3.z = 10.0f;
        v3 = Camera.main.ScreenToWorldPoint(v3);

        transform.position = v3;
    }
}
