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
        //JustTest.GetInstance().DebugTest();
        TimeManager.GetInstance();
        UIManager.GetInstance();
        CameraManager.GetInstance();
        ThirdPersonInputManager.GetInstance();
    }
    // Start is called before the first frame update

}
