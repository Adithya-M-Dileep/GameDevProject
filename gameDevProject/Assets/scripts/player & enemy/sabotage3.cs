using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sabotage3 : MonoBehaviour
{
    public Transform spawnPoint;

    public void startAbility()
    {
        transform.position = spawnPoint.position;
    }
}
