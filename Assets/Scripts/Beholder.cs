using UnityEngine;
using System.Collections;

public class Beholder : MonoBehaviour
{

    public float speed;
    public float turnFreq;
    public float shotRate;
    public float maxSpeed;
    public SpellType spell;

    float turnCount;
    float shotCount;
    Rigidbody2D _rigidb;

    void Start()
    {
        turnCount = turnFreq;
        shotCount = shotRate;
        _rigidb = gameObject.GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        shotCount -= Time.deltaTime;
        turnCount -= Time.deltaTime;

        if (turnCount <= 0)
        {
            speed = speed * -1;
            turnCount = turnFreq;
        }

        if (shotCount <= 0)
        {
            castSpell();
            shotCount = shotRate;
        }

        if (IsAboveMaxSpeed(_rigidb.velocity.x))
            return;

        _rigidb.velocity = _rigidb.velocity + new Vector2(speed, 0);
        if (IsAboveMaxSpeed(_rigidb.velocity.x))
        {
            if (_rigidb.velocity.x > 0)
            {
                _rigidb.velocity = new Vector2(maxSpeed, _rigidb.velocity.y);
            }
            else
            {
                _rigidb.velocity = new Vector2(-maxSpeed, _rigidb.velocity.y);
            }
        }
    }
    bool IsAboveMaxSpeed(float lSpeed)
    {
        if (maxSpeed < lSpeed || -maxSpeed > lSpeed)
            return true;

        return false;

    }

    public void castSpell()
    {
        GetComponent<Unit>().CastSpell(spell, Vector2.zero);
    }
}
