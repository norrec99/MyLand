using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PowerUpData", menuName = "ScriptableObjects/PowerUpData")]
public class PowerUpData : ScriptableObject
{
    public PowerUpType type;
    public int boostAmount;
}
public enum PowerUpType
{
    BagCapacity,
}
