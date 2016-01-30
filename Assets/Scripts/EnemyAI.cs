using UnityEngine;

public class EnemyAI : MonoBehaviour{
	public float jumpForce = 2f;

	// The distance the enemy want to be from the player
	public Vector2 targetDistance;

	[HideInInspector]
	public bool grounded;

	private Player _player;
	private Rigidbody2D _rbody;
	private Unit _unit;
	public bool movementEnabled;

	void Start(){
		_player = Player.Instance;
		if(_player == null){
			Debug.LogError("Player is null...?");
			return;
		}

		_rbody = GetComponent<Rigidbody2D>();
		_unit = GetComponent<Unit>();
	}

	void FixedUpdate(){
		Vector3 delta = _player.transform.position - transform.position;
			
		if(delta.x > targetDistance.x || delta.x < -targetDistance.x){
			if(movementEnabled){
				delta.Normalize();
				_unit.Move(delta.x);
			}
		}
	}

	public void Jump(){
		if(grounded){
			_rbody.AddForce(new Vector2(0, 100*jumpForce));
		}
	}

	void OnCollisionStay2D(Collision2D coll){
		if(coll.gameObject.GetComponent<PlayerControls>() != null){			
			movementEnabled = false;
		}
	}

	void OnCollisionExit2D(Collision2D coll){
		if(coll.gameObject.GetComponent<PlayerControls>() != null){			
			movementEnabled = true;
		}
	}

	void OnCollisionEnter(){
		
	}
}