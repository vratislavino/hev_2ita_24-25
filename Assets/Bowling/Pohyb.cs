using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pohyb : MonoBehaviour
{
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector3.forward * 100 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(-Vector3.forward * 100 * Time.deltaTime);
        }
    }
}
