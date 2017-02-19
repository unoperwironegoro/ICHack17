using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour {
    private string nextSceneName;
    public bool serverSwitch;
    public Texture cutoffTex;

    private float switchTimer;
    private bool switching;

    void Update() {
        if (!switching) {
            return;
        }

        if (switchTimer > 0) {
            switchTimer -= Time.deltaTime;
        } else {
            switchTimer = 0;
            if (serverSwitch) {
                NetworkManager.singleton.ServerChangeScene(nextSceneName);
            } else {
                SceneManager.LoadScene(nextSceneName);
            }
            switching = false;
        }
    }

    public void NextScene(string nextSceneName) {
        if (serverSwitch && !NetworkManager.singleton) {
            return;
        }
        this.nextSceneName = nextSceneName;
        Fader.instance.StartEffect(cutoffTex);
        switching = true;
        switchTimer = Fader.instance.switchTime;
    }

    public void NextScene() {
        if (serverSwitch && !NetworkManager.singleton) {
            return;
        }
        Fader.instance.StartEffect(cutoffTex);
        switching = true;
        switchTimer = Fader.instance.switchTime;
    }
}