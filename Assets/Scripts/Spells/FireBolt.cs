using UnityEngine;
using System.Collections;

public class FireBolt : BoltSpell {
	public override void Activate(){
		speed = 10f;
		base.Activate();
	}
}
