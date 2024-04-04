using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ProductData", menuName = "ScriptableObjects/ProductData")]
public class ProductData : ScriptableObject
{
    public GameObject productPrefab;
    public ProductType productType;
    public int productPrice;
}

public enum ProductType
{
    tomato,
    cabbage,
}
