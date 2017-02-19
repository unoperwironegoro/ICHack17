using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CursorSetter : MonoBehaviour {
    public Texture2D emptyPrefab;
	// Use this for initialization
	void Start () {
        Cursor.SetCursor(emptyPrefab, Vector2.zero, CursorMode.Auto);
    }
}
