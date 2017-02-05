using UnityEngine;
using UnityEngine.Networking;

public class ControlSumo : NetworkBehaviour
{
    public GameObject sumoPrefab;
    private Vector3 startPos = new Vector3(0, 0, 0);

    void Awake()
    {
        if (isLocalPlayer)
        {
            return;
        }

        // Create Racers
        var mouseArray = GameObject.FindGameObjectsWithTag("Mouse");

        int i = 0;
        foreach (GameObject g in mouseArray)
        {
            GameObject sumoObj = Instantiate(sumoPrefab, startPos + new Vector3(i * 3, 0, 0), Quaternion.Euler(0, 0, 0));
            sumoObj.GetComponent<Follower>().mouse = g.transform;
            Color color = g.GetComponent<MouseController>().colour;
            color.a = 1;
            //sumoObj.GetComponent<SpriteRenderer>().color = color;
            NetworkServer.Spawn(sumoObj);
            i++;
        }
    }
}
