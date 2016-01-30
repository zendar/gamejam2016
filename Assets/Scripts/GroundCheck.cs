using UnityEngine;

public class GroundCheck : MonoBehaviour{
	public int numColliders;
	private PlayerControls _playerControls; 
	private EnemyAI _ai;

	void Start(){
		_playerControls = transform.parent.GetComponent<PlayerControls>();
		_ai = transform.parent.GetComponent<EnemyAI>();
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.GetComponent<PlayerControls>() != null){
			// Ourselves
			return;
		}
		numColliders++;
		if(_playerControls != null)
			_playerControls.grounded = true;
		if(_ai != null)
			_ai.grounded = true;
	}

	void OnTriggerExit2D(Collider2D other){
		if(other.GetComponent<PlayerControls>() != null){
			// Ourselves
			return;
		}
		numColliders--;	
		if(numColliders == 0){
			if(_playerControls != null)
				_playerControls.grounded = false;
			if(_ai != null)
				_ai.grounded = false;
		}
	}
}