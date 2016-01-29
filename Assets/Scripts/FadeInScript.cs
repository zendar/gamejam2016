using UnityEngine;
using System.Collections;

public class FadeInScript : MonoBehaviour {

    public Texture2D blackTexturePrefab;
    Texture2D blackTexture;

    private float alphaFadeValue = 0;
    private float fadeTime = 15;

    private bool fadingIn = false; // True if fading in, false if not;
    private bool activeFade = false; // Set to true to start fading


	// Use this for initialization
	void Start () {
        blackTexture = (Texture2D)Instantiate(blackTexturePrefab);
	}
	
	// Update is called once per frame
    void OnGUI()
    {
        GUI.depth = -100;
        if (!activeFade)
        {
            GUI.color = new Color(1, 1, 1, alphaFadeValue);
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), blackTexture, ScaleMode.ScaleAndCrop);
            return;
        }

        float deltaTime = Mathf.Clamp(Time.deltaTime, 0, 0.1f); // Clamp value in case the first frame is long.
        float val = Mathf.Clamp01(deltaTime / fadeTime);

        if (fadingIn)
        {
            alphaFadeValue -= val;
            GUI.color = new Color(1, 1, 1, alphaFadeValue);
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), blackTexture, ScaleMode.ScaleAndCrop);

            if (alphaFadeValue <= 0)
            {
                alphaFadeValue = 0;
                activeFade = false;
            }
        }
        else
        {
            alphaFadeValue += val;
            GUI.color = new Color(1, 1, 1, alphaFadeValue);
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), blackTexture, ScaleMode.ScaleAndCrop);

            if (alphaFadeValue >= 1)
            {
                alphaFadeValue = 1;
                activeFade = false;
            }
        }

//        Debug.Log("Fading in ["+fadingIn+"]. alphaFadeValue = " + alphaFadeValue);
    }


    public void startDefaultFadeIn()
    {
        Debug.Log("Start FadingIn. Default fadeTime");
        startFadeIn(5);
    }

    public void startFadeIn(float fadeTime_)
    {
        Debug.Log("Start FadingIn. fadeTime= [" + fadeTime_ + "].");
        fadeTime = fadeTime_;
        fadingIn = true;
        alphaFadeValue = 1;
        activeFade = true;
    }


    public void startDefaultFadeOut()
    {
        Debug.Log("Start FadingOut. Default fadeTime");
        startFadeOut(5);
    }

    public void startFadeOut(float fadeTime_)
    {
        Debug.Log("Start FadingOut. fadeTime= [" + fadeTime_ + "].");
        fadeTime = fadeTime_;
        fadingIn = false;
        alphaFadeValue = 0;
        activeFade = true;
    }



}
