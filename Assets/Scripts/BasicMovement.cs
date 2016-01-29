using UnityEngine;
using System.Collections;

public class BasicMovement : MonoBehaviour
{
    public float Speed;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        transform.position += move * Speed * Time.deltaTime;
    }
}
