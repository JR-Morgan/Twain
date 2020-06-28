using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpikeController : MonoBehaviour
{
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Triangle")
        {
            Debug.Log($"Spike Object {this.gameObject.name} was touched by a triangle: restartin scene");
            //TODO animation delay
            SceneManager.LoadScene(1);
        }
    }
}
