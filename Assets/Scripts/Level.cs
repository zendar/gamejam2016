using UnityEngine;
using System.Collections.Generic;

public class Level : MonoBehaviour{
	public string name;
	public int index;

	public List<string> relics;
	public Player player;

	public SpellType spellReward;

	void Start(){
		player = Player.Instance;
	}

	bool CheckCompleted(){
		foreach(string relic in relics){
			if(!player.relics.Contains(relic)){
				return false;
			}
		}
		return true;
	}

	void Restart(){
		LevelManager.LoadLevel(name);
	}

	void RelicCollected(string relic){
		Debug.Log("Colected a relic");
		if(CheckCompleted()){
			LevelManager.LoadLevel(LevelManager.Instance.levels[index+1]);
		}
	}
}
