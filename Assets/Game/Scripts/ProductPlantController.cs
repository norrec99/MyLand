using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ProductPlantController : MonoBehaviour
{
    private bool isReadyToHarvest;
    private Vector3 originalScale;

    private void Awake() 
    {
        originalScale = transform.localScale;
        isReadyToHarvest = true;    
    }
    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Player") && isReadyToHarvest)
        {
            StartCoroutine(HarvestProduct());
            Debug.Log("Player Entered");
        }
    }
    IEnumerator HarvestProduct()
    {
        isReadyToHarvest = false;

        Vector3 targetScale = originalScale / 3;
        transform.DOScale(targetScale, 1f);

        yield return new WaitForSeconds(3f);
        
        isReadyToHarvest = true;
        transform.DOScale(originalScale, 1f).SetEase(Ease.OutBack);
    }
}
