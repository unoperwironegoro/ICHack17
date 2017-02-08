using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class NetworkText : MonoBehaviour {

	void Start () {
        var uiText = GetComponent<Text>();

        string formattedText = 
            uiText.text
            .Replace("<ip>", NetworkCalls.nm.networkAddress)
            .Replace("<port>", NetworkCalls.nm.networkPort.ToString());

        uiText.text = formattedText;
    }
}
