using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class ChemVacSript : Instruments
{
    public GameObject ui;

    public Transform target;
    
    float angle, radius = 30;
    float angleSpeed = 5;
    float radialSpeed = 0.5f;
    
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
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            var selectionTransform = hit.transform;
 
            if (selectionTransform.GetComponent<InteractableObject>() && selectionTransform.GetComponent<InteractableObject>().playerInRange 
                                                                      && selectionTransform.GetComponent<Rigidbody>().isKinematic == false && Input.GetKey(KeyCode.Mouse1))
            {
                Debug.Log("Suck");
                Vector3 pos = selectionTransform.GameObject().transform.position;
                selectionTransform.GameObject().transform.position = Vector3.MoveTowards(pos, target.position, 8f * Time.deltaTime);

            }

        }
    }
}
