using UnityEngine;

public class PlayerSpellControls : MonoBehaviour{
	public SpellType[] spells;
	public int activeSpell; // an index for spells

	void Start(){
		//spells = SpellManager.Instance.spells;
	}

	void Update(){
		if(Input.GetButtonDown("Fire1")){
			CastSpell();
		}
	}

	public void CastSpell(){
		if(activeSpell >= spells.Length)
			return;

    	Camera.main.ResetWorldToCameraMatrix();    
        Vector3 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 myPos = new Vector2(transform.position.x, transform.position.y);
        Vector3 direction = target - myPos;
        direction.Normalize();
        Vector2 normalized = (Vector2)direction;
        normalized = normalized / normalized.magnitude;
        GetComponent<Unit>().CastSpell(spells[activeSpell], normalized);
	}
}