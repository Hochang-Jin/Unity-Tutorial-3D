using System;
using UnityEngine;

public class StudyEvent : MonoBehaviour
{
    public delegate void InputKeyHandler();
    public event InputKeyHandler onInputKey;

    void Start()
    {
        onInputKey += InputKeyEvent;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
            onInputKey?.Invoke();
    }

    private void InputKeyEvent()
    {
        Debug.Log("Key Event");
    }
}