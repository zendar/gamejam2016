using UnityEngine;

public class BackgroundMusicController : MonoBehaviour{
	void Awake(){
		DontDestroyOnLoad(gameObject);
	}
}