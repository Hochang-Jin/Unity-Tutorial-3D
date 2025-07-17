using System;
using UnityEngine;

public class SingletonEX5 : MonoBehaviour
{
    private static SingletonEX5 instance;

    public static SingletonEX5 Instance
    {
        get
        {
            if (instance == null)
            {
                var obj = FindFirstObjectByType<SingletonEX5>();// 있는지 찾아
                if (obj != null) // 있으면
                {
                    instance = obj;
                }
                else
                {
                    var newObj = new GameObject("Singleton"); // 새 게임오브젝트 생성
                    newObj.AddComponent<SingletonEX5>();
                    
                    instance = newObj.GetComponent<SingletonEX5>();
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }
    }
}
