using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour{

	public string currentLevel;

	public string[] levels;
	
	private static LevelManager _instance;
	public static LevelManager Instance {
		get{
			return _instance;
		}
	}

	void Awake(){
		_instance = this;
	}

	public static void LoadLevel(string level){
		SceneManager.LoadScene(level);
	}
}