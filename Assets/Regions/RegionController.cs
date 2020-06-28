using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class RegionController : MonoBehaviour
{

    [SerializeField]
    private Colour colour;

    private static readonly Dictionary<Colour, Color> colorMap = new Dictionary<Colour, Color>
    {
        { Colour.White, new Color(0.678f, 0.745f, 0.819f, 0.7f) },
        { Colour.Green, new Color(0.678f, 0.819f, 0.745f, 0.7f) },
        { Colour.Pink, new Color(0.819f, 0.678f, 0.811f, 0.7f) }
    };


    private void OnValidate()
    {
        this.GetComponent<SpriteShapeRenderer>().color = colorMap[colour];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Triangle"))
        {
            collision.gameObject.GetComponent<LockingController>().OnRegionEnter(colour);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Triangle"))
        {
            collision.gameObject.GetComponent<LockingController>().OnRegionExit(colour);
        }
    }
}
