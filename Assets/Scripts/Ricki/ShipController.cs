using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShipController : MonoBehaviour {

	private SceneControllerScript sceneController;

	void Start () {

        GameDataScript.registerPlayerShip(this.gameObject);	
	}
}


