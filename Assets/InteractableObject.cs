using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public string itemName;
    public bool playerInRange;

    public GameObject player;
    
    


    public string GetItemName()
    {
        return itemName;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse1) && playerInRange)
        {   
            Vector3 dir = (player.transform.position - transform.position).normalized;
            Debug.Log("Suck");
            GetComponent<Rigidbody>().AddForce(dir, ForceMode.Impulse);
        }


    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
