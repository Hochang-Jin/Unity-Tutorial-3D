using System;
using UnityEngine;

public class SingletonEX2 : MonoBehaviour
{
    public static SingletonEX2 Instance{get; private set;}

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
}
