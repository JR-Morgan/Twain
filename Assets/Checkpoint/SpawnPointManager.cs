using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointManager : MonoBehaviour
{
    private static SpawnPointManager spawnPoint;

    public static Vector3 LastCheckPointPosition;

    [SerializeField]
    private Transform defaultStartingCheckpoint;

    private void Awake()
    {
        if(spawnPoint == null)
        {
            spawnPoint = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(spawnPoint);
        }

        if (LastCheckPointPosition == Vector3.zero)
        {
            LastCheckPointPosition = defaultStartingCheckpoint.position;
        }
    }


}
