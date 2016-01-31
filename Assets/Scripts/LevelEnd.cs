using UnityEngine;


public class LevelEnd : MonoBehaviour{
	public string nextLevel;
	void OnTriggerEnter2D(Collider2D other){
		Player player = other.gameObject.GetComponent<Player>();
		if(player == null)
			return; // Enemies cant win the game for us >:O

		if(string.IsNullOrEmpty(nextLevel)){
			Debug.Log("Reached end of level, no next level specified though.. :(");
			return;
		}
		LevelManager.LoadLevel(nextLevel);
	}
}