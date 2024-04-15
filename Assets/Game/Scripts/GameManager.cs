using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }
    private int totalCoinAmount;
    public int TotalCoinAmount
    {
        get
        {
            return totalCoinAmount;
        }
    }
    
    private string KeyTotalCoin = "TotalCoin";
    public Action OnCoinChangedAction;

    private void Awake() 
    {
        // Singleton setup
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Start()
    {
        LoadGame();
        AddCoin(0);
    }
    public void AddCoin(int coinAmount)
    {
        totalCoinAmount += coinAmount;
        if (OnCoinChangedAction != null)
        {
            OnCoinChangedAction();
        }
        SaveGame();
    }

    private void SaveGame()
    {
        // Save game data
        PlayerPrefs.SetInt(KeyTotalCoin, totalCoinAmount);
    }
    private void LoadGame()
    {
        // Load game data
        totalCoinAmount = PlayerPrefs.GetInt(KeyTotalCoin, 0);
    }
}
