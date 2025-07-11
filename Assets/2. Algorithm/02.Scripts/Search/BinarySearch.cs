using System;
using UnityEngine;

public class BinarySearch : MonoBehaviour
{
    public int [] array = new []{1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
    public int target;

    private void Start()
    {
        BSearch(array, target);
    }

    void BSearch(int[] arr, int t)
    {
        int left = 0, right = arr.Length - 1;
        int count = 1;
        while (left <= right)
        {
            int mid = (left + right) / 2;
            Debug.Log($"{count}번째 탐색, mid: {mid}, left: {left}, right: {right}");
            if (arr[mid] == t)
            {
                Debug.Log($"{mid}번째에 {t}가 있음");
                return;
            }
            else if (arr[mid] < t)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            } 
            count++;
        }
        
        Debug.Log($"찾는 값 {t} 없음");
       
    }
}
