using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class main : MonoBehaviour
{
    public Text sn;
    public GameObject panel;
    private float timmer, TIMMER;
    private Slider time;
    private bool panelopen = false;

    private void Awake()
    {
        time = GameObject.Find("Slider").GetComponent<Slider>();
    }

    private void Start()
    {
        time.maxValue = 60;
        time.minValue = 0;
        time.wholeNumbers = false;
        time.value = time.maxValue;
        timmer = time.value;
        TIMMER = 60f; 
        sn.text = TIMMER.ToString();
    }

    private void Update()
    {
        if (timmer > 0f) 
        {
            timmer -= Time.deltaTime;
            time.value = timmer;
            TIMMER = Mathf.Ceil(timmer); 
            sn.text = TIMMER.ToString();
            panelopen = false;
        }
        else
        {
            Time.timeScale = 0f;
            panelopen = true;
            
        }

        if (timmer <= 10f)
        {
            sn.gameObject.SetActive(true);
            SN();
        }

        if(panelopen == true)
        {
            panel.SetActive(true);
        }

        else
        {
            panel.SetActive(false);
        }
    }

    public void SN()
    {
        if (TIMMER % 2 == 0)
        {
            sn.color = Color.red;
        }
        else
        {
            sn.color = Color.green;
        }
    }
}
