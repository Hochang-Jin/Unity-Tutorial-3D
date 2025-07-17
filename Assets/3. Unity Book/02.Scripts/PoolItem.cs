using System;
using UnityEngine;

public class PoolItem : MonoBehaviour
{
    private PoolManager poolManager;
    private bool isInit = false;

    private void Awake()
    {
        poolManager = GameObject.FindFirstObjectByType<PoolManager>();
    }

    void OnEnable()
    {
        if(!isInit)
            isInit=true;
        else
            Invoke(nameof(ReturnObject), 2f);
    }

    private void ReturnObject()
    {
        poolManager.pool.Release(gameObject);
    }
}
