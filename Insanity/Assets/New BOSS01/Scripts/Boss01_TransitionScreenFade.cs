using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss01_TransitionScreenFade : MonoBehaviour {
    public Image boss01TransitionScreen;
    public bool _fade;
    public bool faded;

    // Use this for initialization
    void Start () {
        boss01TransitionScreen.canvasRenderer.SetAlpha(0.0f);
        
    }
	
	// Update is called once per frame
	void Update () {
        if (_fade)
        {
            FadeIn();
        } else
        {
            FadeOut();
        }

        if(boss01TransitionScreen.canvasRenderer.GetAlpha() == 0.0f) {
            faded = true;
        } else if (boss01TransitionScreen.canvasRenderer.GetAlpha() == 1.0f) {
            faded = false;
        }
	}

    public void FadeIn()
    {
        boss01TransitionScreen.CrossFadeAlpha(1.0f, 0.5f, true);
    }

    public void FadeOut()
    {
        boss01TransitionScreen.CrossFadeAlpha(0.0f, 0.5f, true);
    }
}
