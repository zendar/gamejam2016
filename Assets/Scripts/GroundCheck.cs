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
        BoxCollider2D collider = gameObject.GetComponent<BoxCollider2D>();
        Vector2 firstPoint = new Vector2 (transform.position.x-collider.size.x/2*transform.localScale.x, transform.position.y - (collider.size.y/2*transform.localScale.y)-0.05f);
        Vector2 secorndPoint = new Vector2(transform.position.x + collider.size.x/2*transform.localScale.x , transform.position.y - (collider.size.y/2*transform.localScale.y)-0.5f);

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

/*	void OnTriggerEnter2D(Collider2D other){
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
   */
}