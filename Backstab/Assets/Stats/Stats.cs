using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat
{
    [SerializeField]
    private int baseValue;
    private int totalValue;

    public int getBaseValue() {
        return baseValue;
    }

    public int getValue()
    {
        return totalValue;
    }

    public void addBuff(float buff) {
        totalValue = baseValue + Mathf.FloorToInt(buff * 100);
    }
}