using UnityEngine;

public class EnemyAI : MonoBehaviour{
	public float jumpForce = 2f;

	// The distance the enemy want to be from the player
	public Vector2 targetDistance;
	public Vector2 wakeDistance;

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

		if(!movementEnabled){
			Bounds bounds = new Bounds(transform.position, wakeDistance);
			if(bounds.Contains(_player.transform.position)){
				movementEnabled = true;
			}
		}
	}

	public void Jump(){
		if(grounded){
			_rbody.AddForce(new Vector2(0, 100*jumpForce));
		}
	}
}