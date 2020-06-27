using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpikeController : MonoBehaviour
{
    
    void OnTriggerEnter2d(Collider2D collider)
    {
        if(collider.transform.parent.tag == "Triangle")
        {
            SceneManager.LoadScene(0);
        }
    }
}
