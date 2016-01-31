using UnityEngine;

public class GroundCheck : MonoBehaviour{
	private PlayerControls _playerControls; 
	private EnemyAI _ai;

	void Start(){
		_playerControls = transform.GetComponent<PlayerControls>();
		_ai = transform.GetComponent<EnemyAI>();
	}
    void FixedUpdate()
    {
        CircleCollider2D collider = gameObject.GetComponent<CircleCollider2D>();
		Vector2 firstPoint = new Vector2((transform.position.x-(collider.radius)*transform.localScale.x)+0.05f, transform.position.y - (collider.radius*transform.localScale.y)-0.28f);
		Vector2 secorndPoint = new Vector2(transform.position.x + collider.radius*transform.localScale.x-0.05f , transform.position.y - (collider.radius*transform.localScale.y)-0.6f);


//		Debug.DrawLine(firstPoint,secorndPoint);

        if (_playerControls != null)
        {
            if (Physics2D.OverlapArea(firstPoint, secorndPoint))
            {
                _playerControls.grounded = true;
            }
            else
            {
                _playerControls.grounded = false;
            }
        }
        if (_ai != null)
        {
            if (Physics2D.OverlapArea(firstPoint, secorndPoint))
            {
                _ai.grounded = true;
            }
            else
            {
                _ai.grounded = false;
            }
        }

    }
}