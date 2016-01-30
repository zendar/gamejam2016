using UnityEngine;

public class PlayerSpellControls : MonoBehaviour{
	public SpellType[] spells;
    public float shotRate;
	public int activeSpell; // an index for spells

    private float shotCounter;
	void Start(){
		spells = SpellManager.Instance.spells;
        shotCounter = shotRate;
	}

	void Update(){
        shotCounter -= Time.deltaTime;

		if(Input.GetButtonDown("Fire1") && shotCounter <= 0){
			CastSpell();
            shotCounter = shotRate;
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
        GetComponent<Unit>().CastSpell(spells[activeSpell], direction);
	}
}