using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBagController : MonoBehaviour
{
    [SerializeField] private Transform bag;
    private void OnTriggerEnter(Collider other) 
    {
        
    }
    public void AddProductToBag(GameObject product)
    {
        product.transform.SetParent(bag);
        product.transform.localPosition = Vector3.zero;
        product.transform.localRotation = Quaternion.identity;
    }
}
