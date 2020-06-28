using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputGraphicsController : MonoBehaviour
{
    [SerializeField]
    private Image w, s, a, d, space;

    private Color gray = Color.gray;
    private Color white = Color.white;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
            w.color = gray;
        if (Input.GetKeyDown(KeyCode.S))
            a.color = gray;
        if (Input.GetKeyDown(KeyCode.A))
            s.color = gray;
        if (Input.GetKeyDown(KeyCode.D))
            d.color = gray;
        if (Input.GetKeyDown(KeyCode.D))
            d.color = gray;
        if (Input.GetKeyDown(KeyCode.Space))
            space.color = gray;


        if (Input.GetKeyUp(KeyCode.W))
            w.color = white;
        if (Input.GetKeyUp(KeyCode.S))
            a.color = white;
        if (Input.GetKeyUp(KeyCode.A))
            s.color = white;
        if (Input.GetKeyUp(KeyCode.D))
            d.color = white;
        if (Input.GetKeyUp(KeyCode.D))
            d.color = white;
        if (Input.GetKeyUp(KeyCode.Space))
            space.color = white;
    }
}
