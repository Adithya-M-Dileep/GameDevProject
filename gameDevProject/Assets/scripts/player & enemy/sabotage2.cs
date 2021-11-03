using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sabotage2 : MonoBehaviour
{
    public GameObject poison;
    public void StartAbility()
    {
        Instantiate(poison, transform.position, transform.rotation);
    }
}
