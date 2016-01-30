using UnityEngine;
using System.Collections;

public class BasicAttack : ContactSpell {
		
	public float damage = 1f;

	public override void Activate(){
		sender.DealDamage(target, this, damage);
		Destroy(this.gameObject);
	}
}
