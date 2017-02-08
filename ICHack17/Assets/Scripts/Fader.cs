using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fader : MonoBehaviour {
    public static Fader instance;

    private Image fader;
    public float totalTime;
    public float idleTime;
    private bool switching;

    private float transTimer;
    private float fadeTime;

    void Awake() {
        DontDestroyOnLoad(gameObject.transform.parent);
        instance = this;
        fadeTime = (totalTime - idleTime) / 2;
        fader = GetComponentInChildren<Image>();
        fader.material.SetFloat("_Cutoff", 0f);
    }

    void Update() {
        if (!switching) {
            return;
        }

        if (transTimer > 0f) {
            transTimer -= Time.deltaTime;
        }
        if (transTimer < 0f) {
            transTimer = 0f;
        }

        float cutoff = transTimer > (totalTime - fadeTime) ? (1 - (transTimer - idleTime - fadeTime) / fadeTime) :
            (transTimer > fadeTime ? 1.0f : (transTimer / fadeTime));


        if (switching) {
            fader.material.SetFloat("_Cutoff", cutoff);
        }

        if (transTimer <= 0f) {
            switching = false;
        }
    }

    public void StartEffect(Texture tex) {
        switching = true;
        transTimer = totalTime;
        fader.material.SetTexture("_TransitionTex", tex);
    }
}
