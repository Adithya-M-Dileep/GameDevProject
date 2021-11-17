using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tabView : MonoBehaviour
{
    public GameObject tabPanel;
    void Start()
    {
        tabPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
            tabPanel.SetActive(true);
        if (Input.GetKeyUp(KeyCode.Tab))
            tabPanel.SetActive(false);
    }
}
