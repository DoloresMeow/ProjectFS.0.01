using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public override void Init()
    {
        base.Init();
    }

    private void Start()
    {
        //UIManager.GetInstance();
        CameraManager.GetInstance();
        //PlayerManager.GetInstance();
    }
    // Start is called before the first frame update

}
