using System;
using UnityEngine;

public class StudyFunc : MonoBehaviour
{
    // <매개변수, 매개변수 ... , 반환값>
    public Func<int, int, int> myFunc1;

    private void Start()
    {
        myFunc1 = (a,b) => a + b;
        
        int result = myFunc1(1,2);
        Debug.Log(result);
    }

}
