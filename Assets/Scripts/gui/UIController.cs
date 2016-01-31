using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour{
	public Text hpText;
	public Text spellText;
	public Text progress;

	private static UIController _instance;
	public static UIController Instance{
		get{
			return _instance;
		}
	}

	void Awake(){
		DontDestroyOnLoad(gameObject);
		_instance = this;
	}

	public void UpdateHP(Unit unit){
		hpText.text = "HP: "+unit.health + "/"+unit.maxHealth;
	}

	public void UpdateProgress(int newProgress){
		progress.text = "Relics: "+newProgress + "/" + Level.Instance.relics.Count;
	}

	public void UpdateSpellSelection(){

		var controller = Player.Instance.GetComponent<PlayerSpellControls>();

		if(controller.activeSpell > 0 && controller.spells.Count > controller.activeSpell)
			spellText.text = "Spell: "+controller.spells[controller.activeSpell].name;
		else
			spellText.text = "No spell";
	}
}