using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ProductPlantController : MonoBehaviour
{
    [SerializeField] private ProductData productData;

    private bool isReadyToHarvest;
    private Vector3 originalScale;

    private PlayerBagController playerBagController;

    private void Awake() 
    {
        originalScale = transform.localScale;
        isReadyToHarvest = true;    
    }
    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Player") && isReadyToHarvest)
        {
            playerBagController = other.GetComponent<PlayerBagController>();
            if (playerBagController.IsEmptySpace())
            {
                playerBagController.AddProductToBag(productData);
                StartCoroutine(HarvestProduct());
            }
        }
    }
    private IEnumerator HarvestProduct()
    {
        isReadyToHarvest = false;

        Vector3 targetScale = originalScale / 3;
        transform.DOScale(targetScale, 1f);

        yield return new WaitForSeconds(3f);
        
        isReadyToHarvest = true;
        transform.DOScale(originalScale, 1f).SetEase(Ease.OutBack);
    }
}
