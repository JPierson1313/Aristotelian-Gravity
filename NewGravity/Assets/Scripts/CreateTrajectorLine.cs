using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTrajectorLine : MonoBehaviour
{
    public GameObject obj1;
    public GameObject obj2;
    public LineRenderer lr;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lr.SetPosition(0, obj1.transform.position);
        lr.SetPosition(1, obj2.transform.position);
    }
}
