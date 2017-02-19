using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(PlayerData))]
public class ColourSync : NetworkBehaviour {
    //Client-side script
    public SpriteRenderer[] colouredSprites;

    [Client]
    void Awake() {
        GetComponent<PlayerData>().OnColorChange += UpdateColours;
    }

    [Client]
    private void UpdateColours(Color color) {
        foreach(SpriteRenderer sr in colouredSprites) {
            sr.color = color;
        }
    }

    override
    public void OnStartClient() {
        UpdateColours(GetComponent<PlayerData>().color);
    }
}
