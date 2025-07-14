using UnityEngine;

public class SelectionSort : MonoBehaviour
{
    private int[] array = { 5, 2, 1, 8, 3, 7, 6, 4 };
    
    void Start()
    {
        Debug.Log($"정렬 전 : {string.Join(", ", array)}");
        Selection(array);
        Debug.Log($"정렬 후 : {string.Join(", ", array)}");
    }

    private void Selection(int[] array)
    {
        int n = array.Length;

        for (int i = 0; i < n - 1; i++) // 특정 값 선택
        {
            int min = array[i];
            int minIndex = i;
            for (int j = i + 1; j < n; j++) // 비교
            {
                if (min > array[j])
                {
                    min = array[j];
                    minIndex = j;
                }
            }
            
            int temp = array[i];
            array[i] = array[minIndex];
            array[minIndex] = temp;
            
        }
    }
}
