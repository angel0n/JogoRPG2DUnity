using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItens : MonoBehaviour
{

    public int totalWood;
    public int totalCarrot;
    public float currentWater;
    
    private float waterLimit = 50;

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
