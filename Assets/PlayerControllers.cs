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
    private float attractionForce = 10f;

    [SerializeField]
    private float pushForce = 20f;


    private Vector3 AttractionDirection() => (this.transform.position - partner.transform.position).normalized;

    public void FixedUpdate()
    {
        var rb = this.GetComponent<Rigidbody2D>();

        rb.bodyType = (lockable && Input.GetKey(KeyCode.Space)) ? RigidbodyType2D.Static : RigidbodyType2D.Dynamic;


        if (!lockable || !Input.GetKey(KeyCode.Space))
        {
            Vector3 force = Vector3.zero;

            if (Input.GetKey(KeyCode.W))
            {
                force = AttractionDirection() * pushForce;
            }
            if (Input.GetKey(KeyCode.S))
            {
                force = AttractionDirection() * attractionForce * -1;
            }

            rb.AddForce(force);
        }
        
    }
}
