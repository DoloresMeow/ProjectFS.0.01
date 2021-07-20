using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;
using UnityEditor.UI;

public class UIManager : Singleton<UIManager>
{
    private string uiRootPath = "UIRoot";
    private GameObject uiRoot;
    private GameObject uiRootPrefab;
    private Canvas uiCanvas;
    private void StartAsync()
    {
        //uiRootPrefab = await Addressables.LoadAssetAsync<GameObject>(uiRootPath).Task;
        Addressables.LoadAssetAsync<GameObject>(uiRootPath).Completed += OnLoadDone;
        //uiRoot = Instantiate(uiRootPrefab);
        
    }

    private void OnLoadDone(AsyncOperationHandle<GameObject> obj)
    {
        uiRootPrefab = obj.Result;
        uiRoot = Instantiate(uiRootPrefab);
        UICanvasInit();
        DontDestroyOnLoad(uiRoot);
    }
    public override void Init()
    {
        StartAsync();
    }

    private void UICanvasInit()
    {
        uiCanvas = uiRoot.GetComponentInChildren<Canvas>();
        uiCanvas.renderMode = RenderMode.ScreenSpaceCamera;
        uiCanvas.worldCamera = CameraManager.GetInstance().UICamera.GetComponent<Camera>();
    }
}
