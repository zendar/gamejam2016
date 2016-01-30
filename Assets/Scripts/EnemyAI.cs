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
			
		if(delta.x > targetDistance.x || delta.y > targetDistance.y || delta.x < -targetDistance.x || delta.y < -targetDistance.y){
			delta.Normalize();
			// Vector3 targetVelocity = delta * walkSpeed;
			// _rbody.velocity += new Vector2(targetVelocity.x, _rbody.velocity.y);
			_unit.Move(delta.x);
		}
	}

	public void Jump(){
		if(grounded){
			_rbody.AddForce(new Vector2(0, 100*jumpForce));
		}
	}
}