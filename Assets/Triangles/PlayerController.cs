using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UIElements;
using UnityEngine.Video;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private GameObject partner;

    [SerializeField]
    private Transform eye;

    #region Movement
    [Header("Movement")]

    [SerializeField]
    private bool rotateable = true;

    [SerializeField]
    [Range(0f, 25f)]
    private float pushForceMultiplier = 12f, pullForceMultiplier = 7f, rotationForceMultiplier = 5f;

    #endregion


    private Vector3 AttractionDirection => (this.transform.position - partner.transform.position).normalized;

    private float TargetDistance => Vector3.Distance(this.transform.position, partner.transform.position);


    private void Start()
    {
        transform.position = SpawnPointManager.LastCheckPointPosition;
    }

    public void FixedUpdate()
    {
        var rb = this.GetComponent<Rigidbody2D>();
        Vector3 force = Vector3.zero;

        if (Input.GetAxis("Vertical") < 0)
        {
            force += AttractionDirection * Input.GetAxis("Vertical") * pushForceMultiplier;
        }
        if (Input.GetAxis("Vertical") > 0)
        {
            force += (AttractionDirection * Input.GetAxis("Vertical") * pullForceMultiplier);
        }
        if (rotateable)
        {
            if (Input.GetAxis("Horizontal") > 0)
            {
                force += Quaternion.AngleAxis(-90, Vector3.forward) * AttractionDirection * rotationForceMultiplier * Input.GetAxis("Horizontal");
            }
            if (Input.GetAxis("Horizontal") < 0)
            {
                force += Quaternion.AngleAxis(90, Vector3.forward) * AttractionDirection * rotationForceMultiplier * -Input.GetAxis("Horizontal");
            }
        }

        rb.AddForce(force);

    }
}
