using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChemVacSript : Instruments
{
    public GameObject ui;
    // Start is called before the first frame update
    void Start()
    {
        ui.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            ui.SetActive(true);
        }
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ui.SetActive(false);
        }
    }
}
