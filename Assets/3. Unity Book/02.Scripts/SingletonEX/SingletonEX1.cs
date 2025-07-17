using System;
using UnityEngine;

public class SingletonEX1 : MonoBehaviour
{
    public static SingletonEX1 Instance;

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
    }
}
