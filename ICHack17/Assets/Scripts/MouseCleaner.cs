using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCleaner : MonoBehaviour {
	void Start () {
        Cursor.visible = true;

        List<GameObject> toDestroy = new List<GameObject>();
        foreach (GameObject mouse in GameObject.FindGameObjectsWithTag("Mouse")) {
            if (mouse != gameObject) {
                Destroy(mouse);
            }
        }
    }
}
