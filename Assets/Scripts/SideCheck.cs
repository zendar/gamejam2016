using UnityEngine;

// Used by enemyai to determine if they should jump
public class SideCheck : MonoBehaviour{
	
	private static EnemyAI _ai;

	void Start(){
		_ai = transform.parent.GetComponent<EnemyAI>();
	}

	void OnTriggerEnter2D(Collider2D other){
		_ai.Jump();
	}

	void OnTriggerStay2D(Collider2D other){
		_ai.Jump();
	}
}