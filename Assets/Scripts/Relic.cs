using UnityEngine;

public class Relic : MonoBehaviour {
	public string name;

	void OnTriggerEnter2D(Collider2D other){
		Player player = other.gameObject.GetComponent<Player>();
		if(player != null){
			player.PickUpRelic(name);
			Destroy(gameObject);
		}
	}
}