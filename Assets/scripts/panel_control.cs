using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class panel_contol: MonoBehaviour
{
    public GameObject panel;
    void Start()
    {
        panel.SetActive(true);
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return) || Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            panel.SetActive(false);
        }
    }
}
