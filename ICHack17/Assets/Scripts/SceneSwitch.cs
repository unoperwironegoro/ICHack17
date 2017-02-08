using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour {
    private string nextSceneName;
    public bool serverSwitch;
    public Texture cutoffTex;

    private float fadeTime = 1.0f;
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
                NetworkCalls.nm.ServerChangeScene(nextSceneName);
            } else {
                SceneManager.LoadScene(nextSceneName);
            }
            switching = false;
        }
    }

    public void NextScene(string nextSceneName) {
        if (serverSwitch && !NetworkCalls.nm) {
            return;
        }
        this.nextSceneName = nextSceneName;
        Fader.instance.StartEffect(cutoffTex);
        switching = true;
        switchTimer = fadeTime;
    }

    public void NextScene() {
        if (serverSwitch && !NetworkCalls.nm) {
            return;
        }
        Fader.instance.StartEffect(cutoffTex);
        switching = true;
        switchTimer = fadeTime;
    }
}