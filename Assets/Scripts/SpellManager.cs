using UnityEngine;

public class SpellManager : MonoBehaviour {

	public SpellType[] spells;

	public static SpellManager _instance;
	public static SpellManager Instance{
		get{
			return _instance;
		}
	}

	void Awake(){
		_instance = this;
	}
}

[System.Serializable]
public class SpellType {
	public string name;
	
	public int manaRequired;
	public SpellCastType cast;
	public Spell prefab;

	public enum SpellCastType{
		Cast, // You activate it yourself
		Contact, // Activated on contact
	}
}