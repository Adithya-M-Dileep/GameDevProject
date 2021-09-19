using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class item : MonoBehaviour
{
    public itemInfo itemInfo;
    public GameObject itemgameobject;

    public abstract void use();
}
