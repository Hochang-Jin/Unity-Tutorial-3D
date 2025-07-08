using System;
using UnityEngine;

public class StudyString : MonoBehaviour
{
    public string str1 = " Hello World***";
    
    public string[] str2 = new string[3]{"Hello", "Unity", "World"};

    private void Start()
    {
        Debug.Log(str1[0]); // H
        Debug.Log(str2[0]); // Hello

        Debug.Log(str1.Length); // 문자열 "Hello World"의 길이 15
        Debug.Log(str1.Trim()); // 앞뒤 공백 제거 "Hello World***"
        Debug.Log(str1.Trim('*')); // 앞 뒤 문자 '*' 제거 " Hello world"
        
        Debug.Log(str2.Length); // 배열의 길이 3
    }
}
