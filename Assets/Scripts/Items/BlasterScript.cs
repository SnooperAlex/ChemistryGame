using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.PlayerLoop;

public class BlasterScript : Instruments
{
    private bool pointerDown;
    private float pointerDownTimer;
    
    public GameObject laserPrefab;

    public GameObject firePoint;

    private GameObject spawnedLaser;
    // Start is called before the first frame update
    void Start()
    {
        spawnedLaser = Instantiate(laserPrefab, firePoint.transform) as GameObject;
        DisableLaser();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        pointerDown = true;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            pointerDown = true;
            EnableLaser();
        }
        
        if (Input.GetMouseButtonUp(0))
        {
            DisableLaser();
            Reset();
        }
        
        if (pointerDown)
        {
            if (firePoint != null)
            {
                spawnedLaser.transform.position = firePoint.transform.position;
                spawnedLaser.transform.rotation = firePoint.transform.rotation;
                spawnedLaser.transform.localScale = firePoint.transform.localScale * 7;
                
            }

       
            pointerDownTimer += Time.deltaTime;
            Debug.Log("hererererrer");
            if (pointerDownTimer > 1)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    var selectionTransform = hit.transform;
 
                    if (selectionTransform.GetComponent<InteractableObject>() && selectionTransform.GetComponent<InteractableObject>().playerInRange 
                                                                              && selectionTransform.GetComponent<InteractableObject>().itemName == "Rock")
                    {
                        selectionTransform.GetComponent<RockChemicalsSpawn>().SpawnChemical();
                    }
                    

                }

                pointerDownTimer = 0;
            }
        }
    }

    void EnableLaser()
    {
        spawnedLaser.SetActive(true);
    }

   

    private void Reset()
    {
        pointerDown = false;
        pointerDownTimer = 0;
    }


    void DisableLaser()
    {
        spawnedLaser.SetActive(false);
    }
}
