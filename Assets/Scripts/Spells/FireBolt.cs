using UnityEngine;
using System.Collections;

public class FireBolt : DamagingBolt {
	public override void Activate(){
		speed = 1f;
		damage = 5f;
		base.Activate();
	}
}
