using UnityEngine;

public class Cauldron : MonoBehaviour {

	public GameObject door;

	void OnTriggerEnter2D(Collider2D other){
		Player player = other.gameObject.GetComponent<Player>();
		if(player != null){
			Debug.Log(player.relics);
			Debug.Log(Level.Instance);
			if(player.relics.Count >= Level.Instance.relics.Count){
				Debug.Log("We got dem crazy relics man");
				Destroy(door);
			}
			
		}
	}
}