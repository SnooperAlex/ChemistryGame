using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChemicalAtom : MonoBehaviour
{
    public ElementCard card;

    public Canvas canvas;
    ChemicalCardDisplay display;
    
    private void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        display = GameObject.FindGameObjectWithTag("UI").GetComponent<ChemicalCardDisplay>();
    }

    public void AssignInfo()
    {
        display.AssignCardInfo(card);
    }
}
