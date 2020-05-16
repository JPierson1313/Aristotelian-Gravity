using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlignGroundSpotWithDropSpotScript : MonoBehaviour
{
    
    public GameObject vPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(vPos.transform.position.x, transform.position.y, transform.position.z);
    }
}
