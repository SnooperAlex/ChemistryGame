using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChemicalAtom : MonoBehaviour
{
    public GameObject player;

    private void OnCollisionStay(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            Debug.Log("hereewrwerrwe");
        }
    }
    
}
