using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Colour { White, Green, Pink }

public class LockingController : MonoBehaviour
{
    [SerializeField]
    private Colour colour;

    private bool isLockable;

    private bool isLocked;

    #region Visual
    [Header("Visual")]
    [SerializeField]
    private float foo = 1f;

    //[SerializeField]
    //private Color colorNonLockable, colorLockable, colorLocked;

    private static readonly Dictionary<Colour, Color> colorNonLockable = new Dictionary<Colour, Color>
    {
        { Colour.Green, new Color(0.713f, 0.956f, 0.043f) },
        { Colour.Pink, new Color(0.474f, 0.678f, 0.011f) }
    },
    colorLockable = new Dictionary<Colour, Color>
    {
        { Colour.Green, new Color(0.462f, 0.015f, 0.031f) },
        { Colour.Pink, new Color(0.145f, 0.603f, 0.050f) }
    },
    colorLocked = new Dictionary<Colour, Color>
    {
        { Colour.Green, new Color(0.207f, 0.078f, 0.019f) },
        { Colour.Pink, new Color(0.501f, 0.776f, 0.047f) }
    };

    #endregion

    #region Controlls

    [Header("Controlls")]
    [SerializeField]
    private KeyCode lockedKey;

    #endregion

    private void OnValidate()
    {
        SetColor();
    }

    private void SetColor()
    {
        Color color;
        if (isLocked)
        {
            color = colorLocked[colour];
        }
        else if (isLockable)
        {
            color = colorLockable[colour];
        }
        else
        {
            color = colorNonLockable[colour];
        }

        var spriteShape = this.GetComponent<UnityEngine.U2D.SpriteShapeRenderer>();
        spriteShape.color = color;
    }

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
    }

    public void OnRegionEnter(Colour colour)
    {
        
        if (colour == this.colour
           || colour == Colour.White)
        {
            isLockable = true;
        }

    }

    public void OnRegionExit(Colour colour)
    {
        if ((colour == this.colour
            || colour == Colour.White)
            && !isLocked)
        {
            isLockable = false;
        }
    }
}
