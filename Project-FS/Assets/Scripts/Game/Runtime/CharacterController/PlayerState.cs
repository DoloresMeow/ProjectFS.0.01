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
    }

}
