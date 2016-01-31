using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitchOnLoad : MonoBehaviour{
	public string scene;


	public void Start(){
		LevelManager.LoadLevel(scene);
	}
}