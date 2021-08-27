using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBase : MonoBehaviour
{
    private int costEnergyValue;
    private string magicName;
    private float liftTime;
    private int magicLevel;
    private GameObject effectPrefab;

    public int CostEnergyValue
    {
        get { return costEnergyValue; }
        set { costEnergyValue = value; }
    }

    public string MagicName
    {
        get { return magicName; }
        set { magicName = value; }
    }

    public float LifeTime
    {
        get { return liftTime; }
        set { liftTime = value; }
    }

    public int MagicLevel
    {
        get { return magicLevel; }
        set { magicLevel = value; }
    }

    public GameObject EffectPrefab
    {
        get { return effectPrefab; }
        set { effectPrefab = value; }
    }

}
