using System;
using UnityEngine;

public class LinearSearch : MonoBehaviour
{
    private int[] array = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    public int target = 7;

    private void Start()
    {
        LSearch(array, target);
    }

    private void LSearch(int[] arr, int t)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == t)
            {
                Debug.Log($"{i}번째에 {t}가 있음");
                return;
            }
        }

        Debug.Log($"찾는 값 {t} 없음");
    }
}
