using NUnit.Framework;
using UnityEngine;

[System.Serializable]
public class MascotLevelBenefit
{
    public int level;
    public float cost;
    public float scoreBonus;
    public float critRate;
    public float extraTime;
    [TextArea]
    public string textDescription;
    public bool unlocked;
}
