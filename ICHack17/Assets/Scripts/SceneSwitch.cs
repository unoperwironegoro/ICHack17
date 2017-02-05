using UnityEngine;
using UnityEngine.SceneManagement;
 
public class SceneSwitch : MonoBehaviour {
    public string nextSceneName;
    public bool serverSwitch;

    public void NextScene() {
        if(serverSwitch) {
            NetworkSceneSwitcher.instance.Switch(nextSceneName);
        } else {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
