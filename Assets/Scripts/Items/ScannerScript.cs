using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScannerScript : Instruments
{
    public InventoryManager inventoryManager;
    public Item item;
    
    public GameObject ui;

    private PickUpController pick;
    
    void Start()
    {
        pick = GetComponent<PickUpController>();
        ui.SetActive(false);
    }
    void Update()
    {
        Item slotItem = inventoryManager.GetSelectedItem(false);
        Debug.Log(slotItem.name);
        if (slotItem == item )
        {
            ui.SetActive(true);
        }
        else
        {
            ui.SetActive(false);
        }

        
    }
}
