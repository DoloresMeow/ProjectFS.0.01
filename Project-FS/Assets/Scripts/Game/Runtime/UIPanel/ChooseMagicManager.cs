using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class ChooseMagicManager : Singleton<ChooseMagicManager>
{
    private string cloudButtonSpritePath = "bt_cloud_icon";
    private Sprite cloudButtonSprite;
    private string chooseMagicLayoutPath = "ChooseMagicLayout";
    private GameObject chooseMagicLayout;
    private GameObject chooseMagicLayoutPrefab;

    private List<Button> magicButtons;
    public override void Init()
    {
        StartAsync();
        //base.Init();

    }

    private void StartAsync()
    {
        Addressables.LoadAssetAsync<Sprite>(cloudButtonSpritePath).Completed += onMagicSpriteLoadDone;
        
    }

    private void onMagicSpriteLoadDone(AsyncOperationHandle<Sprite> obj)
    {
        cloudButtonSprite = obj.Result;
        Addressables.LoadAssetAsync<GameObject>(chooseMagicLayoutPath).Completed += onChooseMagicLayoutLoadDone;
    }

    private void onChooseMagicLayoutLoadDone(AsyncOperationHandle<GameObject> obj)
    {
        chooseMagicLayoutPrefab = obj.Result;
        chooseMagicLayout = Instantiate(chooseMagicLayoutPrefab,transform);
        chooseMagicLayout.SetActive(false);
        InitMagicButtonsList();
    }

    private void InitMagicButtonsList()
    {
        if(magicButtons == null)
        {
            magicButtons = new List<Button>();
        }
        else
        {
            magicButtons.Clear();
        }
        
        //now just have cloud magic, will replace excel later
        if (PlayerState.GetInstance().GetMagicUnderstandState("CloudMagic"))
        {
            GameObject buttonGO = new GameObject();
            buttonGO.transform.SetParent(chooseMagicLayout.transform);
            buttonGO.name = "CloudMagicButton";
            Button button =  buttonGO.AddComponent<Button>();
            button.image = buttonGO.AddComponent<Image>();
            button.image.sprite = cloudButtonSprite;
            buttonGO.AddComponent<CanvasRenderer>();
            magicButtons.Add(button);
        }
    }
    private void ChooseCloudsMagic()
    {

    }

    private void ChooseNullMagic()
    {

    }

    private void ChooseMagicStateChange(bool value)
    {

    }

    public bool GetChooseMaicPanelActive()
    {
        return chooseMagicLayout.activeSelf;
    }

    public void SetChooseMaicPanelActive(bool val)
    {
        chooseMagicLayout.SetActive(val);
    }
}

