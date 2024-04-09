using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UnlockBakeryUnitController : MonoBehaviour
{
    [SerializeField] private TMP_Text bakeryText;
    [SerializeField] private int maxStoredProductCount;
    [SerializeField] private ParticleSystem smokeParticle;
    [SerializeField] private ProductType productType;
    [SerializeField] private Transform CoinTransform;
    [SerializeField] private GameObject CoinPrefab;
    [SerializeField] private int productionDuration = 5;

    private int storedProductCount;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        DisplayProductCount();
    }
    private void Update() 
    {
        if (storedProductCount > 0)
        {
            timer += Time.deltaTime;
            if (timer >= productionDuration)
            {
                timer = 0;
                UseProduct();
            }
        }
    }
    private void DisplayProductCount()
    {
        bakeryText.text = storedProductCount + "/" + maxStoredProductCount;
        ControlSmokeEffect();
    }
    private void IncreaseStoredProductCount()
    {
        storedProductCount++;
    }
    private void UseProduct()
    {
        storedProductCount--;
        DisplayProductCount();
        CreateCoin();
    }
    private void CreateCoin()
    {
        Vector3 coinPosition = Random.insideUnitSphere * 1f;
        Vector3 instantiatePos = CoinTransform.position + coinPosition;
        Instantiate(CoinPrefab, instantiatePos, Quaternion.identity);
    }
    private void ControlSmokeEffect()
    {
        if (storedProductCount > 0)
        {
            smokeParticle.Play();
        }
        else
        {
            smokeParticle.Stop();
        }
    }

    public bool CanStoreProduct()
    {
        if (storedProductCount == maxStoredProductCount)
        {
            return false;
        }
        else
        {
            IncreaseStoredProductCount();
            DisplayProductCount();
            return true;
        }
    }
    public ProductType GetProductType()
    {
        return productType;
    }
}
