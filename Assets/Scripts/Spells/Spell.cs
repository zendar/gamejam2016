using UnityEngine;

public class Spell : MonoBehaviour{
	public SpellType spellType;
	public Unit sender;

	public virtual void Activate(){}
}

// Cast
public class DirectionalSpell : Spell {
	public Vector2 direction;
}

public class BoltSpell : DirectionalSpell {
    public float speed;

	void OnCollisionEnter2D(Collision2D coll){
		Unit other = coll.gameObject.GetComponent<Unit>();
		if(other != null){
			if(other == sender){
				return;
			}
			// explodeee
			Detonate(other);
		}
	}
	public virtual void Detonate(Unit hit){}
    public override void Activate(){
        GetComponent<Rigidbody2D>().velocity = direction * speed;
    }
}



// Activated on contact with another unit
public class ContactSpell : Spell{
	public Unit target;
}

public class RadiusSpell : Spell{}

public class DamagingBolt : BoltSpell {
	public float damage;
	public override void Activate(){
		speed = 5f;
		base.Activate();
	}

	public override void Detonate(Unit hit){
		sender.DealDamage(hit, this, damage);
		Destroy(gameObject);
	}
}
