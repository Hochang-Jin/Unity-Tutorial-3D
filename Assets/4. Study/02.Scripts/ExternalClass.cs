using System;
using UnityEngine;

public class ExternalClass : MonoBehaviour
{
    public StudyUnityEvent studyUnityEvent;

    private void Awake()
    {
        
    }

    private void Start()
    {
        studyUnityEvent.AddListener(Event1);
    }

    private void Event1()
    {
        Debug.Log("Event1");
    }
}
