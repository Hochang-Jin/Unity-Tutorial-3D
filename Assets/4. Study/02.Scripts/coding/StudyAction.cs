using System;
using UnityEngine;

public class StudyAction : MonoBehaviour
{
    public delegate void MyDelegate();
    public event MyDelegate MyEvent;
    // 두개가 같음
    public Action action;
    
    public delegate void MyDelegate2(string s);
    public event MyDelegate2 MyEvent2;
    // 두개가 같음
    public Action<string> action2;

    private void Start()
    {
        action += ()=>Debug.Log("action");
        action += () =>
        {
            Debug.Log("action");
            Debug.Log("action 2");
        };
        
        action?.Invoke();
        action2 += s=>Debug.Log(s);
        action2?.Invoke("action2");
    }
}
