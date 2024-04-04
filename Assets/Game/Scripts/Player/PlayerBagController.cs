using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBagController : MonoBehaviour
{
    [SerializeField] private Transform bag;

    private Vector3 productSize;
    private List<ProductData> productDataList = new List<ProductData>();

    public void AddProductToBag(ProductData productData)
    {
        GameObject productBox = Instantiate(productData.productPrefab, Vector3.zero, Quaternion.identity);
        productBox.transform.SetParent(bag);

        CalculateProductSize(productBox);
        float yPosition = CalculateNewYPositionOfBox();
        productBox.transform.localRotation = Quaternion.identity;
        productBox.transform.localPosition = Vector3.zero;
        productBox.transform.localPosition = new Vector3(0, yPosition, 0);
        productDataList.Add(productData);
    }
    private float CalculateNewYPositionOfBox()
    {
        return productDataList.Count * productSize.y;
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
