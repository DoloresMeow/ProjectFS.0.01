using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerActionState
{
    None,
    ChooseMagic,
    UseMagic
}

public class PlayerState :Singleton<PlayerState>
{
    private readonly int InitialEnergyValue = 20;

    private PlayerActionState playerActionStates; // is choose Magic state,is preuse magic state

    //use magic will cost energy
    private int currentEnergyValue;
    private int maxEnergyValue;    //energy value max limit
    private int recoveryEnergySpeed;    // x value per minute

    //a simple struct. magicName /val = is understand?
    private Dictionary<string,bool> magicList = new Dictionary<string, bool>();

    public Dictionary<string, bool> MagicList
    {
        get { return magicList; }
    }

    private PlayerActionState PlayerActionStates
    {
        get { return playerActionStates; }
        set { playerActionStates = value; }
    }

    public int MaxEnergyValue
    {
        get { return maxEnergyValue; }
        set { maxEnergyValue = value; }
    }

    public int CurrentEnergyValue
    {
        get { return currentEnergyValue; }
        set { currentEnergyValue = value; }
    }

    public int RecoveryEnergySpeed
    {
        get { return recoveryEnergySpeed; }
        set { recoveryEnergySpeed = value; }
    }
    public override void Init()
    {
        playerActionStates = PlayerActionState.None;
        maxEnergyValue = InitialEnergyValue;
        currentEnergyValue = maxEnergyValue;
        recoveryEnergySpeed = 1;
        InitPlayerMagicList();
    }

    private void InitPlayerMagicList()
    {
        magicList.Add("CloudMagic",true);
    }

    public bool GetMagicUnderstandState(string magicName)
    {
        bool state;
        if(magicList.TryGetValue(magicName, out state))
        {
            return state;
        }
        else
        {
            Debug.Log("Have not this magicName,please check out");
            return false;
        }

    }

    public void SetMagicUnderstandState(string magicName,bool value)
    {
        if(!magicList.ContainsKey(magicName))
        {
            Debug.Log("Have not this magicName,please check out");
            return;
        }
        magicList.Remove(magicName);
        magicList.Add(magicName, value);
        
    }
}
