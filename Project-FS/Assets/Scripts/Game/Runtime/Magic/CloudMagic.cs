using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMagic : MagicBase
{
    public enum CloudState
    {
        Small,
        Medium,
        Large
    }

    private CloudState cloudState;
    private void Awake()
    {
        CostEnergyValue = 1;
        cloudState = CloudState.Small;
    }
}
