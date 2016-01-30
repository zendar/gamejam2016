using UnityEngine;

public class Cauldron : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other){
		Player player = other.gameObject.GetComponent<Player>();
		if(player != null){
			if(player.relics.Count >= Level.Instance.relics.Count){
				Debug.Log("We got dem crazy relics man");
			}
			
		}
	}
}