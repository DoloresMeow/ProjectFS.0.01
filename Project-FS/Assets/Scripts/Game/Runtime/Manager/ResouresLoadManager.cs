using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
/// <summary>
/// ��ʱ������ ��֪��addressable��ô��װ
/// </summary>
public class ResouresLoadManager 
{
    private readonly static ResouresLoadManager instence = new ResouresLoadManager();

    //private ResouresLoadManager()
    //{

    //}

    public static ResouresLoadManager GetInstance()
    {
        Addressables.InitializeAsync();
        return instence;
    }

    //private async Task LoadResourcePS(string path)
    //{
    //    //await Addressables.InstantiateAsync(path).;
    //    //Addressables.load
    //    //Debug.Log("Instabtiated finished");
    //}
    

}
