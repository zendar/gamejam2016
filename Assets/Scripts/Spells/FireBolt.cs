using UnityEngine;
using System.Collections;

public class FireBolt : BoltSpell {
	public override void Activate(){
		speed = 1f;
		base.Activate();
	}

	public override void Detonate(Unit hit){
		Destroy(hit.gameObject);
	}
}
