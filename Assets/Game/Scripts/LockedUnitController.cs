using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LockedUnitController : MonoBehaviour
{
    [SerializeField] private int price;
    [SerializeField] private TMP_Text priceText;
    [SerializeField] private GameObject lockedUnit;
    [SerializeField] private GameObject unlockedUnit;

    private bool isPurchased = false;

    // Start is called before the first frame update
    void Start()
    {
        priceText.text = price.ToString();
    }
    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Player") && !isPurchased)
        {
            UnlockUnit();
        }
    }
    private void UnlockUnit()
    {
        if (GameManager.Instance != null)
        {
            if (GameManager.Instance.TotalCoinAmount >= price)
            {
                Unlock();
                GameManager.Instance.AddCoin(-price);
            }
        }
    }
    private void Unlock()
    {
        isPurchased = true;
        lockedUnit.SetActive(false);
        unlockedUnit.SetActive(true);
    }
}
