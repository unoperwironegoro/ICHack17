using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class PaintBox : NetworkBehaviour {
    private Color color;

    [Client]
    void Start() {
        color = GetComponent<Button>().colors.normalColor;
    }

    [Client]
    public void SetPlayerColor() {
        PlayerData.localClientInstance.GetComponent<PlayerData>().SetColor(color);
    }
}
