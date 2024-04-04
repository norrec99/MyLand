using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductPlantController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player Entered");
        }    
    }
}
