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

    private string chooseMagicLayoutPath = "ChooseMagicLayout";
    private GameObject chooseMagicLayout;
    private GameObject chooseMagicLayoutPrefab;
    public GameObject ChooseMagicLayout
    {
        get
        {
            return chooseMagicLayout;
        }
    }
    private void StartAsync()
    {
        Addressables.LoadAssetAsync<GameObject>(uiRootPath).Completed += OnLoadDone;

    }

    private void OnLoadDone(AsyncOperationHandle<GameObject> obj)
    {
        uiRootPrefab = obj.Result;
        uiRoot = Instantiate(uiRootPrefab,this.transform);
        uiCanvas = uiRoot.GetComponentInChildren<Canvas>();
        UICanvasInit(uiCanvas);
        //Debug.Log("Create UI Root");
        //DontDestroyOnLoad(uiRootPrefab);

        Addressables.LoadAssetAsync<GameObject>(chooseMagicLayoutPath).Completed += onChooseMagicLayoutLoadDone;
    }

    private void onChooseMagicLayoutLoadDone(AsyncOperationHandle<GameObject> obj)
    {
        chooseMagicLayoutPrefab = obj.Result;
        chooseMagicLayout = Instantiate(chooseMagicLayoutPrefab,uiRoot.transform);
        chooseMagicLayout.SetActive(false);
    }

    public override void Init()
    {
        StartAsync();
    }

    private void UICanvasInit(Canvas canvas)
    {
        //canvas = uiRoot.GetComponentInChildren<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceCamera;
        canvas.worldCamera = CameraManager.GetInstance().UICamera.GetComponent<Camera>();
    }
}
