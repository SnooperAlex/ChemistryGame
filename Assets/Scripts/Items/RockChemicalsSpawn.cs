using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockChemicalsSpawn : MonoBehaviour
{

    public GameObject[] chemAtoms;

    public GameObject spawner;

    private int rockHp = 5;

    public void SpawnChemical()
    {
        GameObject atom = Instantiate(chemAtoms[Random.Range(0, 3)], spawner.transform.position, Quaternion.identity);
        Rigidbody rb = atom.GetComponent<Rigidbody>();
        rb.AddForce(transform.up * 2, ForceMode.Impulse);
        
        
        
        rockHp -= 1;
        if (rockHp == 0)
        {
            Destroy(gameObject);
        }
    }
    

}
