using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KouleMovement : MonoBehaviour
{
    Rigidbody rb;
    public float force = 10f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            movement.z = 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            movement.z = -1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            movement.x = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            movement.x = 1;
        }

        // normalizace rychlosti (velikosti vektoru)
        movement.Normalize();

        rb.AddForce(movement * force * Time.deltaTime);
    }
}
