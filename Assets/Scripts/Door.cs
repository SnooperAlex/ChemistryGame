using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Animator anim;
    public GameObject player;
    
    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        anim.SetBool("character_nearby", true);
    }

    private void OnTriggerExit(Collider other)
    {
        anim.SetBool("character_nearby", false);
    }
}
