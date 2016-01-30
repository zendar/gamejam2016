using UnityEngine;

public class PlayerSpellControls : MonoBehaviour{
	public SpellType[] spells;
	public int activeSpell; // an index for spells

	void Start(){
		spells = SpellManager.Instance.spells;
	}

	void Update(){
		if(Input.GetKeyDown("Fire1")){
			CastSpell();
		}
	}

	public void CastSpell(){
		if(activeSpell >= spells.Length)
			return;

        Vector2 target = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        Vector2 myPos = new Vector2(transform.position.x, transform.position.y);
        Vector2 direction = target - myPos;
        direction.Normalize();

        GetComponent<Unit>().CastSpell(spells[activeSpell], direction);
	}
}