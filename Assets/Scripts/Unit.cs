using UnityEngine;

public class Unit : MonoBehaviour {
	public bool friendly;
	public float health;
	public float startHealth;
	public float mana;

	public SpellType contactSpell;
	public float contactSpellCooldown;

	void OnCollisionEnter2D(Collision2D coll){
		if(contactSpell == null || contactSpellCooldown > 0)
			return;

		Unit other = coll.gameObject.GetComponent<Unit>();
		if(other != null){
			// Trigger contact spell
			CastContactSpell(contactSpell, other);
		}
	}

	// Just instantiates the spell and sets the spellType and server variables
	private Spell SpawnSpell(SpellType spellType){
		Spell spell = Instantiate(spellType.prefab, transform.position, Quaternion.identity) as Spell;
		spell.spellType = spellType;
		spell.sender = this;
			
		Physics2D.IgnoreCollision(GetComponent<Collider2D>(), spell.GetComponent<Collider2D>(), true);

		return spell;		
	}

	public ContactSpell CastContactSpell(SpellType spellType, Unit other){
		// Instantiates the spell and returns it
		// OVerride to add different animations and whatnot
		ContactSpell spell = SpawnSpell(spellType) as ContactSpell;
		spell.target = other;
		spell.Activate();
		OnSpellCast(spell);
		return spell;
	}

	public Spell CastSpell(SpellType spellType, Vector2 direction){
		DirectionalSpell spell = SpawnSpell(spellType) as DirectionalSpell;
		//spell.transform.position += new Vector3(direction.x, direction.y, 0);
		spell.direction = direction;
		spell.Activate();
		OnSpellCast(spell);
		return spell;
	}

	// Generic castspell method
	public Spell CastSpell(SpellType spellType){
		Spell spell = SpawnSpell(spellType);
		spell.Activate();
		OnSpellCast(spell);
		return spell;
	}


	public virtual void OnSpellCast(Spell spell){
		// Override to add some sort of spellcast effect or something...
		Debug.Log("Cast spell " + spell.spellType.name + "!");
	}

	public virtual void Die(Unit attacker, Spell spell){
		Debug.Log("Got killed by " + spell.spellType.name + " :(");
		Destroy(gameObject);
	}

	// Override for effects and whatnot
	public virtual void TakeDamage(Unit attacker, Spell spell, float damage){
		health -= damage;
		if(health <= 0){
			Die(attacker, spell);
		}
	}

	public virtual void DealDamage(Unit defender, Spell spell, float damage){
		defender.TakeDamage(this, spell, damage);
	}
}