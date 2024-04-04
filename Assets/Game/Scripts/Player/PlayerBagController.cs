using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBagController : MonoBehaviour
{
    [SerializeField] private Transform bag;

    private Vector3 productSize;
    private List<GameObject> productList = new List<GameObject>();

    private void OnTriggerEnter(Collider other) 
    {

    }
    public void AddProductToBag(GameObject product)
    {
        GameObject productBox = Instantiate(product, Vector3.zero, Quaternion.identity);
        productBox.transform.SetParent(bag);

        CalculateProductSize(productBox);
        float yPosition = CalculateNewYPositionOfBox();
        productBox.transform.localRotation = Quaternion.identity;
        productBox.transform.localPosition = Vector3.zero;
        productBox.transform.localPosition = new Vector3(0, yPosition, 0);
        productList.Add(productBox);
    }
    private float CalculateNewYPositionOfBox()
    {
        return productList.Count * productSize.y;
    }
    private void CalculateProductSize(GameObject product)
    {
        if (productSize == Vector3.zero)
        {
            MeshRenderer meshRenderer = product.GetComponent<MeshRenderer>();
            productSize = meshRenderer.bounds.size;
        }
    }
}
