using UnityEngine;

public class Cauldron : MonoBehaviour {
	public GameObject door;

	bool open;

	void OnTriggerEnter2D(Collider2D other){
		if(open)
			return;

		Player player = other.gameObject.GetComponent<Player>();
		if(player != null){
			Debug.Log(player.relics);
			Debug.Log(Level.Instance);
			if(player.relics.Count >= Level.Instance.relics.Count){
				Destroy(door);
				GetComponent<AudioSource>().Play();
				open = true;
				if(!string.IsNullOrEmpty(Level.Instance.spellReward.name)){
					player.GetComponent<PlayerSpellControls>().spells.Add(Level.Instance.spellReward);
					UIController.Instance.UpdateSpellSelection();
				}
			}
		}
	}
}
