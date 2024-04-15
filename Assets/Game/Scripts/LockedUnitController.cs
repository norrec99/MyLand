using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LockedUnitController : MonoBehaviour
{
    [SerializeField] private int price;
    [SerializeField] private int ID;
    [SerializeField] private TMP_Text priceText;
    [SerializeField] private GameObject lockedUnit;
    [SerializeField] private GameObject unlockedUnit;

    private bool isPurchased = false;
    private string keyUnit = "KeyUnit";

    // Start is called before the first frame update
    void Start()
    {
        priceText.text = price.ToString();
        LoadUnit();
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
                SoundController.Instance.PlaySingleSound(SoundType.Sell);
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
        SaveUnit();
    }

    public void SaveUnit()
    {
        PlayerPrefs.SetString(keyUnit + ID, "saved");
    }
    public void LoadUnit()
    {
        if (PlayerPrefs.HasKey(keyUnit + ID))
        {
            Unlock();
        }
    }
}
