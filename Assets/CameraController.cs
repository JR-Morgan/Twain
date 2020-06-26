using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField]
    private GameObject target;

    // Update is called once per frame
    void Update()
    {
        //Vector3 eulerRotation = transform.rotation.eulerAngles;
        //transform.rotation = Quaternion.Euler(
        //    eulerRotation.x,
        //    eulerRotation.y,
        //    Vector3.Angle((this.transform.position - target.transform.position).normalized, Vector3.up));

        Vector3 diff = (target.transform.position - this.transform.position).normalized;

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);

    }
}
