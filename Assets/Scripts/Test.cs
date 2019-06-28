using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public float angle = 0.0f;
    public float rotationSpeed = 100.0f;
    public Vector3 cameraOffset = new Vector3(0.0f, 1.5f, -2.0f);
    public float torque = 200.0f;

    private Rigidbody rb;
    private GameObject gameCamera;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameCamera = GameObject.Find("/Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        var cameraLocalPos = Quaternion.AngleAxis(angle, Vector3.up) * cameraOffset;

        if (gameCamera != null)
        {
            gameCamera.transform.position = transform.position + cameraLocalPos;
            gameCamera.transform.LookAt(transform.position + new Vector3(0.0f, 1.0f, 0.0f));
        }

        {
            var torqueAxis = Vector3.Cross(cameraLocalPos, Vector3.up).normalized;

            if (Input.GetKey("w"))
            {
                rb.AddTorque(torqueAxis * torque);
            }

            if (Input.GetKey("s"))
            {
                rb.AddTorque(-torqueAxis * torque);
            }
        }

        if (Input.GetKey("a"))
        {
            angle -= rotationSpeed * Time.deltaTime;
        }

        if (Input.GetKey("d"))
        {
            angle += rotationSpeed * Time.deltaTime;
        }
    }
}
