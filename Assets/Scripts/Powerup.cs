using UnityEngine;

public class PowerUp : MonoBehaviour{
	public int nextSpellType;

	void OnTriggerEnter2D(Collider2D other){
		PlayerControls player = other.gameObject.GetComponent<PlayerControls>();
		if(player != null){
			player.activeSpell = SpellManager.Instance.spells[nextSpellType];
		}
	}
}