using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PickUpController : MonoBehaviour
{
    public GameObject scannerUi;
    public InventoryManager inventoryManager;
    public Item item;
    
    public Instruments instrumentScript;
    public Rigidbody rb;
    public BoxCollider coll;
    public Transform player, gunContainer, fpsCam, notSelectedContainer;

    public float pickUpRange;
    public float dropForwardForce, dropUpwardForce;

    public bool equipped;
    public static bool slotFull;

    private void Start()
    {
        
        if (!equipped)
        {
            rb.isKinematic = false;
            coll.isTrigger = false;
            instrumentScript.enabled = false;
        }

        if (equipped)
        {
            rb.isKinematic = true;
            coll.isTrigger = true;
            instrumentScript.enabled = true;
            slotFull = true;
        }
    }

    private void Update()
    {
        Vector3 distanceToPlayer = player.position - transform.position;
        if (!equipped && distanceToPlayer.magnitude <= pickUpRange && Input.GetKeyDown(KeyCode.E))
        {
            PickUp();
        }

        if (equipped && Input.GetKeyDown(KeyCode.Q))
        {
            Drop();
        }

        Item slotItem = inventoryManager.GetSelectedItem(false);
        if (slotItem != item)
        {
            scannerUi.SetActive(false);
        }
        if (slotItem == item && equipped)
        {
            transform.SetParent(gunContainer);
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.Euler(Vector3.zero);
            transform.localScale = Vector3.one;
            instrumentScript.enabled = true;
        }
        
        if(equipped && slotItem != item )
        {
            transform.SetParent(notSelectedContainer);
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.Euler(Vector3.zero);
            transform.localScale = Vector3.one;
            instrumentScript.enabled = false;
        }


    }

    private void PickUp()
    {   
        bool result = inventoryManager.AddItem(item);
        if (result == true)
        {
            equipped = true;
            slotFull = true;
        
            transform.SetParent(gunContainer);
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.Euler(Vector3.zero);
            transform.localScale = Vector3.one;

        
            rb.isKinematic = true;
            coll.isTrigger = true;
        }
        else
        {
            Debug.Log("Inventory full");
        }
    }

    private void Drop()
    {
        Item slotItem = inventoryManager.GetSelectedItem(false);
        if (slotItem.name == "Scanner" && equipped)
        {
            scannerUi.SetActive(false);
        }
        if (slotItem == item && equipped)
        {
            equipped = false;
            slotFull = false;

            transform.SetParent(null);

            rb.isKinematic = false;
            coll.isTrigger = false;

            rb.velocity = player.GetComponent<Rigidbody>().velocity;

            rb.AddForce(fpsCam.forward * dropForwardForce, ForceMode.Impulse);
            rb.AddForce(fpsCam.up * dropUpwardForce, ForceMode.Impulse);


            float random = Random.Range(-1f, 1f);
            rb.AddTorque(new Vector3(random, random, random) * 10);
            
            instrumentScript.enabled = false;
        }
        

        inventoryManager.GetSelectedItem(true);
    }
}
