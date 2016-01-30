using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour
{

    public float movementSpeed;
    public float jumpForce;
    public float speed = 5.0f;

    int maxSpeed = 10;
    int minSpeed = -10;
    bool left, right, jump;
    Rigidbody2D player;

    public bool grounded = false;

    // Use this for initialization
    void Start()
    {
        player = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("right"))
        {
            right = true;
        }
        else
        {
            right = false;
        }
        if (Input.GetButton("left"))
        {
            left = true;
        }
        else
        {
            left = false;
        }
        if (Input.GetButtonDown("jump") && grounded)
        {
            Jump();
        }
    }

    void FixedUpdate()
    {
        if (right)
        {   
            player.AddForce(new Vector2(movementSpeed, 0));
            if (player.velocity.x > maxSpeed)
            {
                player.velocity = player.velocity.normalized * maxSpeed;
            }
        }
        else if (left)
        {
            player.AddForce(new Vector2(-movementSpeed, 0));
            if (player.velocity.x < minSpeed)
            {
                player.velocity = player.velocity.normalized * maxSpeed;
            }
        }
    }

    void Jump()
    {
        player.AddForce(new Vector2(0, 100*jumpForce));
    }
}
