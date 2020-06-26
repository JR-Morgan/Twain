using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllers : MonoBehaviour
{
    [SerializeField]
    private GameObject partner;

    [SerializeField]
    private bool lockable = false;

    [SerializeField]
    private float attractionSpeed = 10f;



    public void FixedUpdate()
    {
        var rb = this.GetComponent<Rigidbody2D>();

        if (!lockable || !Input.GetKey(KeyCode.Space))
        {
            Vector3 force = Vector3.zero;

            if (Input.GetKey(KeyCode.W))
            {
                force = partner.transform.position - this.transform.position;
            }
            if (Input.GetKey(KeyCode.S))
            {
                force = this.transform.position - partner.transform.position;
            }

            rb.AddForce(force.normalized * attractionSpeed);
        }
        
    }
}
