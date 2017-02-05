using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkSceneSwitcher : MonoBehaviour {
    public static NetworkSceneSwitcher instance;

    void Awake() {
        instance = this;
    }

    public void Switch(string sceneName) {
        GetComponent<NetworkManager>().ServerChangeScene(sceneName);
    }
}
