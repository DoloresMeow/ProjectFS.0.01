using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine;
public class PlayerManager : Singleton<PlayerManager>
{
    private string playerPath = "Player";
    private GameObject playerPrefab;
    private GameObject player;

    public Transform PlayerCameraRoot;
    public override void Init()
    {
        StartAsync();
    }

    private void StartAsync()
    {
        Addressables.LoadAssetAsync<GameObject>(playerPath).Completed += OnLoadDone;

    }

    private void OnLoadDone(AsyncOperationHandle<GameObject> obj)
    {
        playerPrefab = obj.Result;
        player = Instantiate(playerPrefab,transform);
        //DontDestroyOnLoad(playerPrefab);
        //playerPrefab.SetActive(false);
        player.SetActive(true);
    }
}
