using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    private static T instance;
    public static T GetInstance()
    {
        if (instance == null)
        {
            instance = FindObjectOfType<T>();

            if (instance == null)
            {
                new GameObject(typeof(T).Name).AddComponent<T>();
            }
            else
            {
                instance.Init();
            }
        }
        return instance;
    }

    /// <summary>
    /// If child class need, override this function
    /// </summary>
    /// virtual 虚拟的 可重写
    public virtual void Init()
    {

    }

    protected void Awake()
    {
        if(instance == null)
        {
            instance = this as T;
            Init();
        }
        else
        {
            if(instance !=this)
            {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);
    }
}
