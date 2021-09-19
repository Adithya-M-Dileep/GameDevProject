using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagers : MonoBehaviour
{
    public static SpawnManagers instance;
    spawnPoint[] spawnpointss;

    private void Awake()
    {
        instance = this;
        spawnpointss = GetComponentsInChildren<spawnPoint>();
    }
    public Transform GetSpawnPoint()
    {
        return spawnpointss[Random.Range(0, spawnpointss.Length)].transform;
    }
}
