using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBrokenVersion : MonoBehaviour
{
    public GameObject breakVersion;
    public float bForce = 0;

    public Rigidbody2D rb;
    private bool isHit;

    public float v;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        v = rb.velocity.magnitude;
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.relativeVelocity.magnitude > bForce && !isHit)
        {
            Instantiate(breakVersion, transform.position, transform.rotation);
            isHit = true;
            Destroy(gameObject);
            //Debug.Log(collision.relativeVelocity);
        }
    }
}
