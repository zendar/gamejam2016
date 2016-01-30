using UnityEngine;

public class PlayerUnit : Unit{
	public override void Die(Unit attacker, Spell spell){
		Debug.Log("Ded");
	}
}