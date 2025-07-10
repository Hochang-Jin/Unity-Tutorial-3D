using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolQueue : MonoBehaviour
{
    public Queue<GameObject> objQueue = new Queue<GameObject>();
    
    public GameObject objPrefab;
    public Transform parent;

    private void Start()
    {
        CreateObject();
    }

    public void CreateObject()
    {
        for (int i = 0; i < 30; i++)
        {
            GameObject obj = Instantiate(objPrefab, parent);
            EnqueueObject(obj);
        }
    }

    public void EnqueueObject(GameObject obj)
    {
        objQueue.Enqueue(obj);
        obj.SetActive(false);
    }

    public GameObject DequeueObject()
    {
        if(objQueue.Count < 10)
            CreateObject();
        
        GameObject obj = objQueue.Dequeue();
        obj.SetActive(true);
        return obj;
        
    }
}
