using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Parallaxing : MonoBehaviour
{
    public Transform[] backgrounds;
    private float[] parallaxMovementScale;
    public float smoothing = 1f;
    [SerializeField]
    private Transform cam;

    private Vector3 previousCamPos;

    void Awake()
    {
        //GameObject[] go = GameObject.FindGameObjectsWithTag("Background");
        //backgrounds[0] = go[0].transform;
        // GameObject.FindGameObjectsWithTag("background").transform;
        //cam = Camera.main.transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        previousCamPos = cam.position;
        parallaxMovementScale = new float[backgrounds.Length];

        for (int i = 0; i < backgrounds.Length; i++)
        {
            parallaxMovementScale[i] = backgrounds[i].position.z;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < backgrounds.Length; i++)
        {
            float parallax = (cam.position.x - previousCamPos.x) * parallaxMovementScale[i];

            float backgroundTargetPositionX = backgrounds[i].position.x + parallax;

            Vector3 backgroundTargetPosition = new Vector3(backgroundTargetPositionX, backgrounds[i].position.y, backgrounds[i].position.z);

            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPosition, smoothing * Time.deltaTime);
        }

        previousCamPos = cam.position;
    }
}
