using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CannonSystem : MonoBehaviour
{
    public Slider rotationSlider;
    public Slider powerSlider;

    public float rotateSpeed = 1;

    public GameObject projectile;
    public Transform launcherEnd;
    public float launchSpeed;

    public float impetus;
    public Transform angleB;

    public TextMeshPro angleText;
    public TextMeshPro powerText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
        ////Rotation System Start---------------------------------------------------
        Quaternion rotMin = Quaternion.Euler(new Vector3(0, 0, 10f));
        Quaternion rotMax = Quaternion.Euler(new Vector3(0, 0, 80f));

        Quaternion rotation = transform.rotation;

        rotationSlider.value = transform.localEulerAngles.z;
        angleText.text = "a:" + rotationSlider.value;

        if (rotation.z < rotMin.z)
        {
            transform.eulerAngles = new Vector3(0, 0, 10f);
        }

        if (rotation.z > rotMax.z)
        {
            transform.eulerAngles = new Vector3(0, 0, 80f);
        }

        if (Input.GetKey(KeyCode.W) && rotation.z < rotMax.z || Input.GetKeyDown(KeyCode.W) && rotation.z < rotMax.z)
        {
            transform.Rotate(Vector3.forward * rotateSpeed);
        }

        if (Input.GetKey(KeyCode.S) && rotation.z > rotMin.z || Input.GetKeyDown(KeyCode.S) && rotation.z > rotMin.z)
        {
            transform.Rotate(Vector3.back * rotateSpeed);
        }
        ////Rotation System End-----------------------------------------------------

        ////Power System Begin------------------------------------------------------
        launchSpeed = powerSlider.value;
        powerText.text = "Power:" + powerSlider.value;

        if (Input.GetKey(KeyCode.D) && powerSlider.value < powerSlider.maxValue  || Input.GetKeyDown(KeyCode.D) && powerSlider.value < powerSlider.maxValue)
        {
            powerSlider.value += 1;
            angleB.localPosition = new Vector2(angleB.localPosition.x + 0.2f, 0);
        }

        if (Input.GetKey(KeyCode.A) && powerSlider.value > powerSlider.minValue || Input.GetKeyDown(KeyCode.A) && powerSlider.value > powerSlider.minValue)
        {
            powerSlider.value -= 1;
            angleB.localPosition = new Vector2(angleB.localPosition.x - 0.2f, 0);
        }
        ////Power System End--------------------------------------------------------

        ////Firing System Start-----------------------------------------------------
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject P = Instantiate(projectile, launcherEnd.position, launcherEnd.rotation);
            impetus = launchSpeed * (10 * P.GetComponent<Rigidbody2D>().mass);
            P.gameObject.GetComponent<Rigidbody2D>().AddForce(launcherEnd.right * impetus);
        }
        ////Firing System End-------------------------------------------------------
    }
}
