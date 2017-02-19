using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerData : NetworkBehaviour {
    public static PlayerData localClientInstance;
    [HideInInspector][SyncVar(hook = "OnColorChangeHook")] public Color color = Color.white;
    [HideInInspector][SyncVar(hook = "OnScoreChangeHook")] public float score = 0f;

    public delegate void ColorChange(Color c);
    public ColorChange OnColorChange;
    public delegate void ScoreChange(float s);
    public ScoreChange OnScoreChange;

    void Start() {
        if(isLocalPlayer) {
            localClientInstance = this;
        }
    }

    public void OnColorChangeHook(Color c) {
        OnColorChange(c);
    }

    public void OnScoreChangeHook(float s) {
        OnScoreChange(s);
    }

    void Awake() {
        DontDestroyOnLoad(gameObject);
    }

    public void SetColor(Color c) { CmdSetColor(c); }
    [Command]
    private void CmdSetColor(Color c) {
        color = c;
    }
}
