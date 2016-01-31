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
		DontDestroyOnLoad(gameObject);
	}

	public static void LoadLevel(string level){
		Instance.currentLevel = level;
		SceneManager.LoadScene(level);
	}

	public static void Reload(){
		Debug.Log(Instance.currentLevel);
		SceneManager.LoadScene(Instance.currentLevel);
	}
}