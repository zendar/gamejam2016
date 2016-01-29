using UnityEngine;
using System.Collections;

public class GameInitScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.SendMessage("loadLevel",Level.LevelTypes.INTRO_SPLASH);
	}
	
}
