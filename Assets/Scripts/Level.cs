using UnityEngine;
using System.Collections.Generic;

public class Level : MonoBehaviour{
	public string name;
	public int index;

	public List<string> relics;
	public Player player;

	public SpellType spellReward;

	private static Level _instance;
	public static Level Instance{
		get{
			return _instance;
		}
	}

	void Awake(){
		_instance = this;
	}

	void Start(){
		player = Player.Instance;
		
		UIController.Instance.UpdateSpellSelection();
		UIController.Instance.UpdateHP(Player.Instance.GetComponent<Unit>());
		UIController.Instance.UpdateProgress(0);
	}

	void Restart(){
		LevelManager.LoadLevel(name);
	}
}
