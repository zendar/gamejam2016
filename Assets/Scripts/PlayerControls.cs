using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour
{

    public float movementSpeed;
    public float speed = 5.0f;

    int maxSpeed = 10;
    int minSpeed = -10;
    bool left, right, jump;
    Rigidbody2D player;

    public SpellType activeSpell;

    // Use this for initialization
    void Start()
    {
        player = gameObject.GetComponent<Rigidbody2D>();
        activeSpell = SpellManager.Instance.spells[0];
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
        if (Input.GetButtonDown("jump") && player.velocity.y == 0)
        {
            Jump();
        }
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
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
        player.AddForce(new Vector2(0, 200));
    }

    void Shoot()
    {
        Vector2 target = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        Vector2 myPos = new Vector2(transform.position.x, transform.position.y);
        Vector2 direction = target - myPos;
        direction.Normalize();
        GetComponent<Unit>().CastSpell(activeSpell, direction);
    }
}
