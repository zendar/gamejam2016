using UnityEngine;

public class Relic : MonoBehaviour {
	string name;

	void OnTriggerEnter2D(Collider2D other){
		Player player = other.gameObject.GetComponent<Player>();
		if(player != null){
			player.relics.Add(name);
			Destroy(gameObject);
		}
	}
}