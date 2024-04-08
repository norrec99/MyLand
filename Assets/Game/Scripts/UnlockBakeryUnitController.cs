using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UnlockBakeryUnitController : MonoBehaviour
{
    [SerializeField] private TMP_Text bakeryText;
    [SerializeField] private int maxStoredProductCount;
    [SerializeField] private ProductType productType;

    private int storedProductCount;

    // Start is called before the first frame update
    void Start()
    {
        DisplayProductCount();
    }
    private void DisplayProductCount()
    {
        bakeryText.text = storedProductCount + "/" + maxStoredProductCount;
    }
}
