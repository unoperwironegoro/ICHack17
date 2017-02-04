using UnityEngine;
using UnityEngine.Networking;

public class MouseSpriter : NetworkBehaviour {
    private SpriteRenderer sr;

    void Awake() {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update new player's colour for connected players

    public override void OnStartLocalPlayer() {
        Color color = Random.ColorHSV();
        color.a = 0.5f;

        CmdUpdateColors(color);

        if(isLocalPlayer) {
            Cursor.visible = false;
        }
    }

    [Command]
    void CmdUpdateColors(Color color) {
        // Set previously connected players' colours
        foreach(GameObject mouse in GameObject.FindGameObjectsWithTag("Mouse")) {
            if(mouse != gameObject)
                mouse.GetComponent<MouseSpriter>().CmdSendColor();
        }

        GetComponent<SpriteRenderer>().color = color;
        RpcSetColor(color);
    }

    [Command]
    void CmdSendColor() {
        RpcSetColor(sr.color);
    }

    [ClientRpc]
    void RpcSetColor(Color color) {
        sr.color = color;
    }
}
