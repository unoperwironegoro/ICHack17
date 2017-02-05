using UnityEngine;
using UnityEngine.Networking;

public class MouseController : NetworkBehaviour {
    public Color colour = Color.white;
    public float score = 0f;

    private SpriteRenderer sr;

    void Awake() {
        DontDestroyOnLoad(gameObject);
        sr = GetComponentInChildren<SpriteRenderer>();
    }

    // Update new player's colour for connected players

    public override void OnStartLocalPlayer() {
        Color color = Random.ColorHSV();
        color.a = 0.7f;
        this.colour = color;

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
                mouse.GetComponent<MouseController>().CmdSendColor();
        }

        sr.color = color;
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
