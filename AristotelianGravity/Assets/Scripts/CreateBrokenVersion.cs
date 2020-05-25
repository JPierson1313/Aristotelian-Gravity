using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBrokenVersion : MonoBehaviour
{
    public GameObject breakVersion; //This is the broken object for the walls of the castle
    public float bForce = 0; //The amount of force needed to break the object

    public Rigidbody2D rb; //Used for detecting collisions with the cannonball
    private bool isHit; //Is used for the collision to detect where the object has been hit

    // Start is called before the first frame update
    void Start()
    {
        //Gets the rigidbody2D from the object this script is attach to
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //When the collision of the cannonball or another object is greater than the force needed to break and isHit is false
        //Instantiate the brokenObject in place of the non broken version and destroy the non broken version as well
        if (collision.relativeVelocity.magnitude > bForce && !isHit)
        {
            Instantiate(breakVersion, transform.position, transform.rotation);
            isHit = true;
            Destroy(gameObject);
        }
    }
}
