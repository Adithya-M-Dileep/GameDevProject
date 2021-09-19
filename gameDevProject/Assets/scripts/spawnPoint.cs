using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnPoint : MonoBehaviour
{
    [SerializeField] GameObject graphics;
    private void Awake()
    {
        graphics.SetActive(false);        
    }

}
