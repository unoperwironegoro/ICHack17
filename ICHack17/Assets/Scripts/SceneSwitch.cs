using UnityEngine;
using UnityEngine.SceneManagement;
 
public class SceneSwitch : MonoBehaviour {
    public string nextSceneName;

    public void NextScene() {
        SceneManager.LoadScene(nextSceneName);
    }
}
