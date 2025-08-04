using System;
using UnityEngine;
using UnityEngine.UI;

public class StudyLambda : MonoBehaviour
{
    public delegate void MyDelegate(string s);
    public event MyDelegate lambda;

    public Button button;

    private void Start()
    {
        button.onClick.AddListener(() =>
        {
            OnLog("aa");
            OnLog("bb");
        });
        
        lambda += (s) =>
        {
            OnLog(s);
            OnLog(s);
        };
        
        lambda?.Invoke("hello unity");
    }

    void OnLog(string s)
    {
        Debug.Log(s);
        Debug.Log(s);
    }
}
