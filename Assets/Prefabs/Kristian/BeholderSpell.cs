using UnityEngine;
using System.Collections;

public class BeholderSpell : DamagingBolt
{
    public override void Activate()
    {
        speed = 20f;
        damage = 5f;
        base.Activate();
        Destroy(gameObject, 2f);
    }

    public override void Detonate(Unit hit)
    {
        Vector3 delta = hit.transform.position - transform.position;
        hit.GetComponent<Rigidbody2D>().AddForce(new Vector2(delta.normalized.x * 100.0f, delta.normalized.y * 100.0f));
        base.Detonate(hit);
    }
}
