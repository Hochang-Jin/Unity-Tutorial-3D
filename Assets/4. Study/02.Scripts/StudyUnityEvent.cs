using System;
using UnityEngine;
using UnityEngine.Events;

public class StudyUnityEvent : MonoBehaviour
{
    [SerializeField] private UnityEvent onUnityEvent;

    private void OnEnable()
    {
        onUnityEvent.AddListener(MethodA);
    }

    private void OnDisable()
    {
        onUnityEvent.RemoveListener(MethodA);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
            onUnityEvent?.Invoke();
    }

    public void AddListener(UnityAction method)
    {
        onUnityEvent.AddListener(method);
    }

    private void MethodA()
    {
        Debug.Log("Method A");
    }
}
