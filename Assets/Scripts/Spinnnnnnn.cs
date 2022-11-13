using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinnnnnnn : MonoBehaviour
{
    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 r = transform.rotation.eulerAngles;
        r.z += 5;
        transform.rotation = Quaternion.Euler(r);
    }
}
