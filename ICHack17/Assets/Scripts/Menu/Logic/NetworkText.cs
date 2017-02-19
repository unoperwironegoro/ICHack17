using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class NetworkText : MonoBehaviour {

	void Start () {
        var uiText = GetComponent<Text>();

        string formattedText = 
            uiText.text
            .Replace("<ip>", NetworkManager.singleton.networkAddress.ToString())
            .Replace("<port>", NetworkManager.singleton.networkPort.ToString());

        uiText.text = formattedText;
    }
}
