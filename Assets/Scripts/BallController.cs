using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody cam;

    private Rigidbody rb;

    private int direction = 0;

    private bool fall;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (fall == false)
        {
            cam.velocity = rb.velocity;
            if (direction == 1)
            {
                rb.velocity = new Vector3(0f, 0f, speed);
                
            }
            else if (direction == 2)
            {
                rb.velocity = new Vector3(speed, 0f, 0f);
            }


            if (Input.GetMouseButtonDown(0))
            {
                if (direction != 2)
                {
                    direction = 2;
                }
                else
                {
                    direction = 1;
                }

            }
        }
        else
        {
            cam.velocity = Vector3.zero;
            rb.velocity = new Vector3(0f, -speed, 0f);
        }
        

    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            fall = true;
        }
    }
}
