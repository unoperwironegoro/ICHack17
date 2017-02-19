using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerData : NetworkBehaviour {
    public static PlayerData localClientInstance;
    [HideInInspector][SyncVar(hook = "OnColorChangeHook")] public Color color;
    [HideInInspector][SyncVar(hook = "OnScoreChangeHook")] public float score;

    public delegate void ColorChange(Color c);
    public ColorChange OnColorChange;
    public delegate void ScoreChange(float s);
    public ScoreChange OnScoreChange;

    void Start() {
        if(isLocalPlayer) {
            localClientInstance = this;
        }
        color = Color.white;
        score = 0f;
    }

    public void OnColorChangeHook(Color c) {
        if(OnColorChange != null) {
            OnColorChange(c);
        }
    }

    public void OnScoreChangeHook(float s) {
        if(OnScoreChange != null) {
            OnScoreChange(s);
        }
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
