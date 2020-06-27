using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField]
    private Transform triangle1;
    [SerializeField]
    private Transform triangle2;

    [SerializeField]
    private bool fixedRotation;


    [SerializeField]
    [Range(0,1)]
    private float smoothAmount;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            fixedRotation = !fixedRotation;
        }

        if(!fixedRotation)
        {
            Vector3 diff = (triangle1.transform.position - this.transform.position).normalized;

            float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
        }
        
    }

    private void LateUpdate()
    {

        Vector3 midPoint = Vector3.Lerp(triangle1.transform.position, triangle2.transform.position, 0.5f);
        transform.position = Vector3.Lerp(transform.position, new Vector3(midPoint.x, midPoint.y, -20), smoothAmount * 10 * Time.deltaTime);
        

    }
}
