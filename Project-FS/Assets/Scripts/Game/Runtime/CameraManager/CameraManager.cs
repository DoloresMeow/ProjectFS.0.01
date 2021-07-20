using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine;

public class CameraManager : Singleton<CameraManager>
{
    private string cameraRootPath = "CameraRoot";
    private GameObject cameraRoot;
    private GameObject cameraRootPrefab;
    private GameObject mainCamera;
    private GameObject uiCamera;

    private Camera uiCameraComponent;
    private Camera mainCameraComponent;
    private ThirdPersonCamera mainCameraController;
    public GameObject MainCamera
    {
        get 
        {  return mainCamera; }
    }

    public GameObject UICamera
    {
        get
        { return uiCamera; }
    }
    public Camera MainCameraComponent
    {
        get
        {
            return mainCameraComponent;
        }
    }

    public ThirdPersonCamera MainCameraController
    {
        get
        {
            return mainCameraController;
        }
    }

    private void StartAsync()
    {
        Addressables.LoadAssetAsync<GameObject>(cameraRootPath).Completed += onCameraLoadDone;
    }

    private void onCameraLoadDone(AsyncOperationHandle<GameObject> obj)
    {
        cameraRootPrefab = obj.Result;
        cameraRoot = Instantiate(cameraRootPrefab);
        LoadCamera();

    }
    public override void Init()
    {
        StartAsync();
        //base.Init();
    }

    private void LoadCamera()
    {
        if(mainCamera != null && uiCamera !=null)
        {
            return;
        }
        foreach (Transform item in cameraRoot.transform)
        {
            if(item.name.Contains("Main Camera"))
            {
                mainCamera = item.gameObject;
                InitMainCamera();
            }
            if (item.name.Contains("UICamera"))
            {
                uiCamera = item.gameObject;
                InitUICamera();
            }
        }
    }

    protected virtual void InitUICamera()
    {
        uiCameraComponent = uiCamera.GetComponent<Camera>();
        uiCameraComponent.cullingMask =1<<5;
    }

    protected virtual void InitMainCamera()
    {
        mainCameraComponent = mainCamera.GetComponent<Camera>();
        if(!mainCamera.TryGetComponent(out mainCameraController))
        {
            mainCameraController = mainCamera.AddComponent<ThirdPersonCamera>();
        }
        //mainCamera.transform.localPosition = new Vector3(0, 2, -20);
        //mainCamera.transform.localRotation = Quaternion.Euler(10, 0, 0);
    }
}
