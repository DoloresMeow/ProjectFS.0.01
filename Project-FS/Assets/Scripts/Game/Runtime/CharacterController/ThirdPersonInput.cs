using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonInput : MonoBehaviour
{
    #region Variables
    public string horizontalInput = "Horizontal";
    public string verticallInput = "Vertical";

    public ThirdPersonController controller;
    public ThirdPersonCamera tpCamera;
    #endregion

    protected virtual void Start()
    {
        InitilizeController();
        //InitializeCamera();
    }

    protected virtual void FixedUpdate()
    {
        controller.AirControl();
    }

    protected virtual void Update()
    {
        InputHandle();
    }

    protected virtual void InitilizeController()
    {
        controller = GetComponent<ThirdPersonController>();
        //if (controller != null)
        //    controller.Init();
    }

    protected virtual void InitializeCamera()
    {
        if(tpCamera == null)
        {
            tpCamera = CameraManager.GetInstance().MainCameraController;
            if(!tpCamera)
            {
                tpCamera = FindObjectOfType<ThirdPersonCamera>();
            }
            if (tpCamera)
            {
                tpCamera.SetMainTarget(transform);
                tpCamera.Init();
            }
        }
    }
    protected virtual void InputHandle()
    {
        MoveInput();
    }

    public virtual void MoveInput()
    {
        controller.input.x = Input.GetAxis(horizontalInput);
        controller.input.z = Input.GetAxis(verticallInput);
    }
}
