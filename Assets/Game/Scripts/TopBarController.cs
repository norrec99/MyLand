using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TopBarController : MonoBehaviour
{
    [SerializeField] private TMP_Text coinText;

    private void Start() 
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnCoinChangedAction += UpdateUI;
        }
        UpdateUI();
    }
    private void OnDestroy() 
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnCoinChangedAction -= UpdateUI;
        }
    }

    private void UpdateUI()
    {
        coinText.text = GameManager.Instance.TotalCoinAmount.ToString();
    }
}
