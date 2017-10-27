using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 10.0F;
    public float amplitude = 0.5f;
    public float frequency = 1f;

    protected Vector3 upForce = Vector3.up;
    private bool flightModeEnabled = false;
    Rigidbody rb;

    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
        posOffset = transform.position;
    }

    void Update()
    {
        if (flightModeEnabled)
        {
            float translation = Input.GetAxis("Vertical") * speed;
            float straffe = Input.GetAxis("Horizontal") * speed;
            translation *= Time.deltaTime;
            straffe *= Time.deltaTime;

            transform.Translate(straffe, translation, translation);

            if (Input.GetKeyDown("space"))
            {
                DisableFlightMode();
            }
            //tempPos = posOffset;
            //tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;

            //transform.position = tempPos;
        }
        else
        {
            float translation = Input.GetAxis("Vertical") * speed;
            float straffe = Input.GetAxis("Horizontal") * speed;
            translation *= Time.deltaTime;
            straffe *= Time.deltaTime;

            transform.Translate(straffe, 0, translation);

            if (Input.GetKeyDown("escape"))
                Cursor.lockState = CursorLockMode.None;

            if (Input.GetKeyDown("space"))
            {
                EnableFlightMode();
            }
        }
    }

    protected void EnableFlightMode()
    {
           flightModeEnabled = true;
           rb.useGravity = false;
    }

    protected void DisableFlightMode()
    {
        flightModeEnabled = false;
        rb.useGravity = true;
    }
}
