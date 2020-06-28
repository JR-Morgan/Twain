using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputGraphicsController : MonoBehaviour
{
    private bool spaceToggle = false;
    [SerializeField]
    private Image w, s, a, d, space;
    [SerializeField]
    private Color gray = Color.gray;
    [SerializeField]
    private Color white = Color.white;
    [SerializeField]
    private Color pink = Color.magenta;
    [SerializeField]
    private Color green = Color.green;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
            w.color = gray;
        if (Input.GetKeyDown(KeyCode.S))
            s.color = gray;
        if (Input.GetKeyDown(KeyCode.A))
            a.color = gray;
        if (Input.GetKeyDown(KeyCode.D))
            d.color = gray;
        if (Input.GetKeyDown(KeyCode.Space))
            spaceToggle = !spaceToggle;


        space.color = spaceToggle ? pink : green;


        if (Input.GetKeyUp(KeyCode.W))
            w.color = white;
        if (Input.GetKeyUp(KeyCode.S))
            s.color = white;
        if (Input.GetKeyUp(KeyCode.A))
            a.color = white;
        if (Input.GetKeyUp(KeyCode.D))
            d.color = white;
        //if (Input.GetKeyUp(KeyCode.Space))
           //space.color = white;
    }
}
