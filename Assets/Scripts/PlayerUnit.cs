using UnityEngine;

public class PlayerUnit : Unit{
	public override void Die(Unit attacker, Spell spell){
		LevelManager.Reload();
	}

	public override void TakeDamage(Unit attacker, Spell spell, float damage){
		base.TakeDamage(attacker, spell, damage);
		UIController.Instance.UpdateHP(this);
	}

	void OnLevelWasLoaded(int level){
		health = maxHealth;
	}
}