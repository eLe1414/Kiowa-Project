using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomizationTrigger : MonoBehaviour
{
    public GameObject customMenu;

    void Start() 
    {
        customMenu.SetActive(false);
    }

    public void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            customMenu.SetActive(true);
        }
    }

    public void OnTriggerExit(Collider other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            customMenu.SetActive(false);
        }
    }
}
