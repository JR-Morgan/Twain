using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Colour { White, Green, Pink }

public class LockingController : MonoBehaviour
{
    [SerializeField]
    private Colour colour;

    private int lockableZones = 0;
    private bool IsLockable => lockableZones > 0;

    private bool isLocked;

    #region Visual
    [Header("Visual")]
    [SerializeField]
    private float foo = 1f;

    //[SerializeField]
    //private Color colorNonLockable, colorLockable, colorLocked;

    private static readonly Dictionary<Colour, Color> colorNonLockable = new Dictionary<Colour, Color>
    {
        { Colour.Green, new Color(0.38f,0.7f,0.07f) },
        { Colour.Pink, new Color(0.71f,0.24f,0.47f) }
    },
    colorLockable = new Dictionary<Colour, Color>
    {
        { Colour.Green, new Color(0.19f,0.7f,0.14f) },
        { Colour.Pink, new Color(0.61f,0.07f,0.44f) }
    },
    colorLocked = new Dictionary<Colour, Color>
    {
        { Colour.Green, new Color(0.05f,0.38f,0.25f) },
        { Colour.Pink, new Color(0.53f,0.24f,0.71f) }
    },
    colorWaitingToLock = new Dictionary<Colour, Color>
    {
        {Colour.Green, new Color(1f,1f,1f) },
        {Colour.Pink, new Color(1f,1f,1f) }
    };

    #endregion

    #region Controlls

    [Header("Controlls")]
    [SerializeField]
    private KeyCode lockedKey;
    [SerializeField]
    private bool lockBool;

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
        else if (IsLockable)
        {
            color = colorLockable[colour];
        }
        else if (lockBool)
        {
            color = colorWaitingToLock[colour];
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

    public void Update()
    {
        if (Input.GetKeyDown(lockedKey))
        {
            lockBool = !lockBool;
        }
        LockMovement(IsLockable && lockBool);
    }

    public void OnRegionEnter(Colour colour)
    {

        if (colour == this.colour
           || colour == Colour.White)
        {
            lockableZones = 1;
        }

    }

    public void OnRegionExit(Colour regionColour)
    {
        if ((regionColour == this.colour
            || regionColour == Colour.White)
            && !isLocked
            && lockableZones > 0
            )
        {
            lockableZones = 0;
        }
    }
}