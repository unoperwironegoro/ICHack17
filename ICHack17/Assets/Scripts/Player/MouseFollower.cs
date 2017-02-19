using UnityEngine;
using UnityEngine.Networking;

public class MouseFollower : NetworkBehaviour {

    [Client]
    void Start() {
        UpdatePosition();
    }

    [Client]
    void Update () {
        UpdatePosition();
    }

    [Client]
    private void UpdatePosition() {
        if (!isLocalPlayer) {
            return;
        }

        var v3 = Input.mousePosition;
        v3.z = 10.0f;
        v3 = Camera.main.ScreenToWorldPoint(v3);

        transform.position = v3;
    }
}
