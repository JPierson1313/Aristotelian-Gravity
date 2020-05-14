using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AristotelianGravityScript : MonoBehaviour
{
    public CannonSystem cs;
    public Rigidbody2D rb;
    public bool hasStopped;

    public float i;

    public float speed;

    private int active;
    // Start is called before the first frame update
    void Start()
    {
        cs = GameObject.FindGameObjectWithTag("CS").GetComponent<CannonSystem>();
        i = cs.launchSpeed * (10 * rb.mass);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        speed = rb.velocity.magnitude;
        i /= rb.mass;
        if(i == 0)
        {
            //rb.velocity = 4.53592f * rb.mass * Vector2.down;
            rb.velocity = new Vector2(0, rb.velocity.y);
            rb.gravityScale = rb.mass;
            Debug.Log(rb.velocity);
            hasStopped = true;
        }

        if(hasStopped == true && active == 0)
        {
            active = 1;
            rb.velocity = Vector2.zero;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        i = 0;
    }
}
