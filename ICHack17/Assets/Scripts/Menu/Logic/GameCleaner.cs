using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GameCleaner : MonoBehaviour {
	void Start () {
        Cursor.visible = true;

        foreach (GameObject mouse in GameObject.FindGameObjectsWithTag("Mouse")) {
            if (mouse != gameObject) {
                Destroy(mouse);
            }
        }

        Destroy(NetworkManager.singleton.gameObject);
    }
}
