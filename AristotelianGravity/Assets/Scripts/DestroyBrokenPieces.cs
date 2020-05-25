using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script's main purpose is to destroy all of the broken pieces created within 7 seconds after being instantiated
/// </summary>

public class DestroyBrokenPieces : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 7);
    }
}
