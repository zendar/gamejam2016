using UnityEngine;
using System.Collections.Generic;

public class Player : MonoBehaviour{
	public List<string> relics = new List<string>();

	private static Player _instance;
	public static Player Instance {
		get{
			return _instance;
		}
	}

	void Awake(){
		_instance = this;
		SimpleCameraFollow.target = transform;
	}

	void Start(){
	}

	void CastSpell(){
		
	}
}