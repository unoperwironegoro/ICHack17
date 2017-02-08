using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkCancel : MonoBehaviour {
    public void CancelConnection() {
        NetworkCalls.nm.StopClient();
    }
}
