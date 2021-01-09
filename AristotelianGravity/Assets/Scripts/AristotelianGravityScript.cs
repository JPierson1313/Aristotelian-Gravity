using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is the main script that does all of the controls for Aristotelian Gravity in terms of the cannonball's Impetus and when the cannonball will drop after losing all of it Impetus
/// This script also controls the gravity for the projectile by setting its gravity to its mass due to Aristotle explaining that heavier objects will fall faster than lighter objects
/// </summary>

public class AristotelianGravityScript : MonoBehaviour
{
    public CannonSystem cs; //Getting the CannonSystem script
    public Rigidbody2D rb; //The cannonball's rigidbody
    public bool hasStopped; //Boolean use to see if the cannonball has stopped moving in the air after losing all of its impetus

    private float i; //I is the impetus of the projectile

    public int active; //This integer is used to help with stopping the cannonball after losing its impetus by zeroing out its velocity


    // Getting access to the CannonSystem script and setting the Impetus of the cannonball since its formula is Impetus = Velocity x Weight
    void Start()
    {
        cs = GameObject.FindGameObjectWithTag("CS").GetComponent<CannonSystem>();
        i = cs.launchSpeed * (10 * rb.mass);
    }

    
    void FixedUpdate()
    {
        //Here we are dividing the Impetus by the Cannonball's mass because in Aristotle's theory, the impetus will slow down due to cannonball's mass
        i /= rb.mass;

        //When the impetus reaches zero, we would stop the cannonball then tell the velocity to go downward and set the to the object's mass
        if(i <= 0)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            rb.gravityScale = rb.mass;
            hasStopped = true;
        }

        //We zero out the velocity once so that way the object does not have any forces acting on it
        if(hasStopped == true && active == 0)
        {
            active = 1;
            rb.velocity = Vector2.zero;
        }
    }
}
