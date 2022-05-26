using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItens : MonoBehaviour
{
     [Header("Amounts")]
    public int totalWood;
    public int totalCarrot;
    public float currentWater;

    [Header("Limits")]
    public float waterLimit = 50;
    public float carrotLimit = 15;
    public float woodLimit = 10;

    public void waterIncrement(float water)
    {
        if(currentWater + water < waterLimit) 
        {
            currentWater += water;
        }else
        {
            currentWater = waterLimit;
        }
        
    }
}
