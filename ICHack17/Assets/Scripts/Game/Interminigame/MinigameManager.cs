using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MinigameManager : MonoBehaviour {
    public static MinigameManager singleton { private set; get; }

    private List<string> unplayedMinigames;
    public string[] minigameNames;

	void Awake () {
		if(singleton == null) {
            singleton = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
	}

    void Start() {
        unplayedMinigames = new List<string>();
        Debug.Log(minigameNames.Length);
        for (int i = 0; i < minigameNames.Length; i++) {
            unplayedMinigames.Add(minigameNames[i]);
        }
    }
	
	public string ConsumeUnplayedMinigame() {
        string minigameID = unplayedMinigames[Random.Range(0, unplayedMinigames.Count)];
        unplayedMinigames.Remove(minigameID);
        return minigameID;
    }
}
