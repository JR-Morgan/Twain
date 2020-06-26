using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.Video;

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

    private bool isLocked;

    private static readonly Color colorLockable = new Color(0.75f, 0.15f, 0.50f),
                                  colorLocked = new Color(0.75f, 0.15f, 0.15f),
                                  colorNonLockable = new Color(0.15f, 0.75f, 0.50f);



    public void Start()
    {
        SetColor();
    }


    private void SetColor()
    {
        var spriteShape = this.GetComponent<SpriteShapeRenderer>();
        spriteShape.color = lockable ? (isLocked ? colorLocked : colorLockable) : colorNonLockable;
    }

    private Vector3 AttractionDirection() => (this.transform.position - partner.transform.position).normalized;

    private void LockMovement(bool isLocked)
    {
        this.isLocked = isLocked;

        var rb = this.GetComponent<Rigidbody2D>();
        rb.bodyType = isLocked ? RigidbodyType2D.Static : RigidbodyType2D.Dynamic;
        SetColor();
    }


    public void FixedUpdate()
    {
        LockMovement(lockable && Input.GetKey(KeyCode.Space));

        if (!lockable || !Input.GetKey(KeyCode.Space))
        {
            var rb = this.GetComponent<Rigidbody2D>();
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
