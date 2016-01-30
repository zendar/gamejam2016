using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShipController : MonoBehaviour {

	private GameObject camera;


	private SceneControllerScript sceneController;

	// Use this for initialization
	void Start () {


		camera = GameObject.Find("Main Camera");

        GameDataScript.registerPlayerShip(this.gameObject);
        sceneController = (SceneControllerScript)GameObject.Find("Main Camera").GetComponent("SceneControllerScript");
        if (sceneController == null)
        {
            Debug.LogError("SceneControllerScript is null!. Bad initialization.");
        }


	
	}
}


