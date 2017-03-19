using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkCalls : MonoBehaviour {
    public void StartServer() {
        NetworkManager.singleton.StartHost();
    }

    public void JoinServer() {
        NetworkManager.singleton.StartClient();
    }

    public void CloseLobby() {
        NetworkManager.singleton.StopHost();
    }

    public void CancelConnectionAttempt() {
        NetworkManager.singleton.StopClient();
    }
}
