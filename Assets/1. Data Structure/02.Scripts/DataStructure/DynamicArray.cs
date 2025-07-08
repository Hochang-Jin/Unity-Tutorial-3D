using System;
using System.Collections.Generic;
using UnityEngine;

// public class DynamicArray : MonoBehaviour
// {
//     private object[] array = new object[3];
//
//     void Add(object o)
//     {
//         var temp = new object[array.Length + 1];
//         for (int i = 0; i < array.Length; i++)
//         {
//             temp[i] = array[i];
//         }
//         array = temp;
//         array[array.Length - 1] = o;
//     }
// }

public class DynamicArray : MonoBehaviour
{
    public List<int> list1 = new List<int>() { 1, 2, 3 };
    
    private void Start()
    {
        list1.Add(10);
        
        for(int i = 0; i < 10; i++)
            list1.Add(i);
        
        list1.Insert(5,1000);

        list1.Remove(5); // 값 5를 제거
        list1.RemoveAt(5); // 인덱스 5번을 제거
        list1.RemoveRange(1, 3); // 인덱스 1번부터 3개까지 지운다
    }
    
}
