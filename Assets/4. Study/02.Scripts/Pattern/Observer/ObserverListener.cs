using System;
using UnityEngine;

public class ObserverListener : MonoBehaviour, IObserver
{
    public Subject subject;

    private void OnEnable()
    {
        subject.AddObserver(this);
    }

    private void OnDisable()
    {
        subject.RemoveObserver(this);
    }

    public void Notify(int score)
    {
        Debug.Log("알람");
    }
}
