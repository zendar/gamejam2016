using UnityEngine;

public class LevelManager : MonoBehaviour{

	private static LevelManager _instance;
	public static LevelManager Instance {
		get{
			return _instance;
		}
	}

	void Awake(){
		_instance = this;
	}
}