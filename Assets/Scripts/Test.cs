using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public float torque;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w"))
        {
            rb.AddTorque(transform.right * torque);
        }

        if (Input.GetKey("s"))
        {
            rb.AddTorque(-transform.right * torque);
        }

        if (Input.GetKey("d"))
        {
            rb.AddTorque(-transform.up * torque);
        }

        if (Input.GetKey("a"))
        {
            rb.AddTorque(transform.up * torque);
        }
    }
}
