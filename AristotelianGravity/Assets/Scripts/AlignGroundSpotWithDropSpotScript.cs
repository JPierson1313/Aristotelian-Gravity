using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script's main function is for the gameObject that this script is attach to to keep in in the same X coordinate as with the Drop Spot where the cannonball will drop
/// This is also useful to keep the line renderer striaght that is also used that is use to show the trajectory of the cannonball vertically 
/// </summary>
public class AlignGroundSpotWithDropSpotScript : MonoBehaviour
{
    public GameObject vPos; //This gameObject represents the Drop Spot where the cannonball will fall to the ground


    // Update is called once per frame
    void Update()
    {
        //Movement system to make the ground spot gameObject follow the drop spot's X coordinate
        transform.position = new Vector3(vPos.transform.position.x, transform.position.y, transform.position.z);
    }
}
