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
    public void AddCoin(int coinAmount)
    {
        totalCoinAmount += coinAmount;
        if (OnCoinChangedAction != null)
        {
            OnCoinChangedAction();
        }
    }
}
