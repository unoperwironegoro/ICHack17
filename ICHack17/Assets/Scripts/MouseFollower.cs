using UnityEngine;
using UnityEngine.Networking;

public class MouseFollower : NetworkBehaviour {
    void Update () {
        if (!isLocalPlayer) {
            return;
        }

        var v3 = Input.mousePosition;
        v3.z = 10.0f;
        v3 = Camera.main.ScreenToWorldPoint(v3);

        transform.position = v3;
    }
}
