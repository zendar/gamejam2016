using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour{
	void Update(){
		if(Input.GetMouseButton(0)){
			// Goto intro
			SceneManager.LoadScene("Intro");
		}
	}
}
