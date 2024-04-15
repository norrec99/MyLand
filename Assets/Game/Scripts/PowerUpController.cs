using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    [SerializeField] private PowerUpData powerUpData;
    [SerializeField] private int lockedUnitID;
    
    private bool isPowerUpUsed;
    private string powerUpStatusKey = "PowerUpStatusKey";

    private void Start() 
    {
        isPowerUpUsed = GetPowerUpStatus();    
    }
    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Player") && !isPowerUpUsed)
        {
            SoundController.Instance.PlaySingleSound(SoundType.Grab);
            PlayerBagController bagController = other.GetComponent<PlayerBagController>();
            bagController.AddPowerUp(powerUpData.boostAmount);
            PlayerPrefs.SetString(powerUpStatusKey, "used");
            isPowerUpUsed = GetPowerUpStatus();
        }
    }
    private bool GetPowerUpStatus()
    {
        string status = PlayerPrefs.GetString(powerUpStatusKey, "ready");
        if (status == "ready")
        {
            return false;
        }
        return true;
    }
}
