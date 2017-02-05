using UnityEngine;
using UnityEngine.Networking;

public class MouseController : NetworkBehaviour {
    // Exists on the Server only
    public Color colour {
        get { return sr.color; }
    }

    public float score = 0f;
    public bool isDown = false;

    private SpriteRenderer sr;

    private void Update()
    {
        isDown = Input.GetMouseButtonDown(0);
    }

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

        this.colour = color;
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

    [Command]
    public void CmdWinPoint() {
        score++;
    }
}
