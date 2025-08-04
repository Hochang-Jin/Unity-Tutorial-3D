using System;
using UnityEngine;
using UnityEngine.UI;

public class StudyDelegate : MonoBehaviour
{
    public delegate void MyDelegate();
    public MyDelegate myDelegate;
    
    public KeyCode key = KeyCode.Space;

    private Button button;
    public bool isTimer = true;
    public float timer;

    void Start()
    {
        myDelegate += Respond;
        myDelegate += StopTimer;
        myDelegate += StopBomb;
    }

    private void Update()
    {
        if(isTimer)
            timer += Time.deltaTime;
        
        if(Input.GetKeyDown(key))
            myDelegate?.Invoke();
    }

    public void AddMethod(MyDelegate myDelegate)
    {
        myDelegate += myDelegate;
    }

    private void Respond()
    {
        Debug.Log("키가 눌렸습니다");
    }

    private void StopTimer()
    {
        isTimer = false;
        Debug.Log("타이머 정지");
    }

    private void StopBomb()
    {
        Debug.Log("폭탄 기능 정지");
    }
}
