using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(MouseSync))]
public class MouseAnim : NetworkBehaviour {
    public float clickRotation = 90f;
    private MouseSync mouseSync;

    void Awake() {
        mouseSync = GetComponent<MouseSync>();
    }

    [Client]
    void Update() {
        transform.rotation = mouseSync.LMB? Quaternion.Euler(0, 0, clickRotation) : Quaternion.identity;
    }
}
