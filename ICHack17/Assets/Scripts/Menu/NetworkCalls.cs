using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkCalls : MonoBehaviour {
    public static NetworkManager nm;

    void Awake() {
        nm = GetComponent<NetworkManager>();
    }

    public void StartServer() {
        GetComponent<NetworkManager>().StartServer();
    }

    public void JoinServer() {
        GetComponent<NetworkManager>().StartClient();
    }
}
