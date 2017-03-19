using UnityEngine;
using UnityEngine.Networking;

public class ControlRace : NetworkBehaviour {
    public GameObject carPrefab;
    private Vector3 startPos = new Vector3(0, 5, 0);

	void Awake ()
    {
        if(isLocalPlayer) {
            return;
        }

        // Create Racers
        var mouseArray = GameObject.FindGameObjectsWithTag("Mouse");

        int i = 0;
        foreach (GameObject g in mouseArray) {
            GameObject carObj = Instantiate(carPrefab, startPos + new Vector3(i, 0, 0), Quaternion.Euler(0, 0, 0));
            carObj.GetComponent<MouseChaser>().mouse = g;
            carObj.GetComponent<SpriteRenderer>().color = g.GetComponent<PlayerData>().color;
            NetworkServer.Spawn(carObj);
            i++;
        }
    }
}
