using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Networking;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
[RequireComponent(typeof(SceneSwitch))]
public class ReadyUp : NetworkBehaviour {
    public int minPlayers;
    private int numReadyCursors;

    public Text readyText;
    private Image image;
    private Color originalColour;
    public Color hoverColour;

    [Client]
    void Start () {
        readyText.text = "";
        image = GetComponent<Image>();
        originalColour = image.color;
	}
	
    [ClientRpc]
	void RpcSetReadyMessage (string readyMessage) {
        readyText.text = readyMessage;
	}

    [Client]
    public void OnCursorEnter() {
        CmdUpdateReadyCursor(1);
        image.color = hoverColour;
    }

    [Client]
    public void OnCursorExit() {
        CmdUpdateReadyCursor(-1);
        image.color = originalColour;
    }

    [Command]
    private void CmdUpdateReadyCursor(int change) {
        numReadyCursors += change;
        if (EnoughCursorsReady()) {
            StartCoroutine("Countdown");
        } else {
            StopCoroutine("Countdown");
            RpcSetReadyMessage("");
        }
    }

    [Server]
    private bool EnoughCursorsReady() {
        int numPlayers = CustomNetworkManager.GetPlayers().Length;
        return numReadyCursors >= minPlayers && numReadyCursors == numPlayers;
    }

    [Server]
    IEnumerator Countdown() {
        int countdown = 3;
        while (countdown > 0) {
            RpcSetReadyMessage("" + countdown);
            countdown--;
            yield return new WaitForSeconds(1f);
        }
        GetComponent<SceneSwitch>().NextMinigame();
    }
}
