using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.Video;

public class PlayerControllers : MonoBehaviour
{
    [SerializeField]
    private GameObject partner;

    #region Movement
    [Header("Movement")]

    [SerializeField]
    private int lockableLayer;

    private float ForceCalculation(float forceMultipler, float distance, float range) => forceMultipler;

    [SerializeField]
    private bool rotateable = true;

    [SerializeField]
    [Range(0f, 25f)]
    private float pushForceMultiplier = 12f, pullForceMultipler = 7f, rotationForceMultiplier = 5f;
    [Range(0f, 10f)]
    [SerializeField]
    private float pushRange = 2f, pullRange = 2f, rotationRange = 2f;
    private float PushForce => ForceCalculation(pushForceMultiplier, TargetDistance, pushRange);
    private float PullForce => ForceCalculation(pullForceMultipler, TargetDistance, pullRange);

    private float RotationForce => ForceCalculation(rotationForceMultiplier, TargetDistance, rotationRange);

    #endregion

    #region Visual
    [Header("Visual")]
    [SerializeField]
    [Range(0f, 2f)]
    private float particalScale = 1f;

    [SerializeField]
    private Color colorNonLockable, colorLockable, colorLocked;
    #endregion

    #region Controlls

    [Header("Controlls")]
    [SerializeField]
    private KeyCode lockedKey;

    #endregion

    private bool isLockable;

    private bool isLocked;


    private void SetColor()
    {
        Color color;
        if(isLocked)
        {
            color = colorLocked;
        }
        else if(isLockable)
        {
            color = colorLockable;
        }
        else
        {
            color = colorNonLockable;
        }

        var spriteShape = this.GetComponent<SpriteShapeRenderer>();
        spriteShape.color = color;
    }

    private Vector3 AttractionDirection => (this.transform.position - partner.transform.position).normalized;

    private float TargetDistance => Vector3.Distance(this.transform.position, partner.transform.position);

    private void LockMovement(bool isLocked = true)
    {
        this.isLocked = isLocked;

        var rb = this.GetComponent<Rigidbody2D>();
        rb.bodyType = isLocked ? RigidbodyType2D.Static : RigidbodyType2D.Dynamic;
        SetColor();
    }


    public void FixedUpdate()
    {

        LockMovement(isLockable && Input.GetKey(lockedKey));

        if(!isLocked)
        {
            var rb = this.GetComponent<Rigidbody2D>();
            Vector3 force = Vector3.zero;

            if (Input.GetAxis("Vertical") < 0)
            {
                Debug.Log("Negative");
                force += AttractionDirection * Input.GetAxis("Vertical") * PushForce * -1 ;
            }
            if (Input.GetAxis("Vertical") > 0)
            {
                force += (AttractionDirection * Input.GetAxis("Vertical")  * PullForce * -1);
            }
            if(rotateable)
            {
                force += Quaternion.AngleAxis(135, Vector3.forward) * AttractionDirection * RotationForce * Input.GetAxis("Horizontal");
            }    

            rb.AddForce(force);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == lockableLayer)
        {
            isLockable = true;
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == lockableLayer
            && !isLocked)
        {
            isLockable = false;
        }
    }
}
