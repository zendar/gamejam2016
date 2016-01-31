using UnityEngine;

public class PlayerUnit : Unit{
	public override void Die(Unit attacker, Spell spell){
		Debug.Log("Ded");
	}

	void OnLevelWasLoaded(int level){
		health = maxHealth;
	}
}