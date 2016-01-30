using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour
{

    public float movementSpeed;
    public float jumpForce;

    int minSpeed = -10;
    Rigidbody2D player;

    public bool grounded = false;

    private Unit _unit;

    // Use this for initialization
    void Start()
    {
        player = gameObject.GetComponent<Rigidbody2D>();
        _unit = GetComponent<Unit>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("jump") && grounded)
        {
            Jump();
        }
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        if(horizontal != 0)
            _unit.Move(horizontal);
    }

    void Jump()
    {
        player.AddForce(new Vector2(0, 100*jumpForce));
    }
}
