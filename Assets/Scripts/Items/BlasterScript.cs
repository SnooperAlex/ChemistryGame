using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BlasterScript : Instruments
{
    public GameObject laserPrefab;

    public GameObject firePoint;

    private GameObject spawnedLaser;
    // Start is called before the first frame update
    void Start()
    {
        spawnedLaser = Instantiate(laserPrefab, firePoint.transform) as GameObject;
        DisableLaser();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            EnableLaser();
        }

        if (Input.GetMouseButton(0))
        {
            UpdateLaser();
        }

        if (Input.GetMouseButtonUp(0))
        {
            DisableLaser();
        }
    }

    void EnableLaser()
    {
        spawnedLaser.SetActive(true);
    }

    void UpdateLaser()
    {
        if (firePoint != null)
        {
            spawnedLaser.transform.position = firePoint.transform.position;
            spawnedLaser.transform.rotation = firePoint.transform.rotation;
            spawnedLaser.transform.localScale = firePoint.transform.localScale * 7;
            
        }
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            var selectionTransform = hit.transform;
 
            if (selectionTransform.GetComponent<InteractableObject>() && selectionTransform.GetComponent<InteractableObject>().playerInRange 
                                                                      && selectionTransform.GetComponent<InteractableObject>().itemName == "Rock")
            {
                Destroy(selectionTransform.GameObject());
            }

        }
    }

    void DisableLaser()
    {
        spawnedLaser.SetActive(false);
    }
}
