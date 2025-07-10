using UnityEngine;

public class Permutation : MonoBehaviour
{
    public int[] array = new int[3] { 1, 2, 3 };
    void Start()
    {
        PermutationFunction(array, 0);
    }

    void PermutationFunction(int[] array, int start)
    {
        if (start == array.Length)
        {
            Debug.Log(string.Join(",", array));
            return;
        }

        for (int i = start; i < array.Length; i++)
        {
            // Swap
            var temp = array[i];
            array[i] = array[start];
            array[start] = temp; 
            
            PermutationFunction(array, start + 1);
            
            // back Tracking
            temp = array[start];
            array[start] = array[i];
            array[i] = temp;
        }
    }
    
}
