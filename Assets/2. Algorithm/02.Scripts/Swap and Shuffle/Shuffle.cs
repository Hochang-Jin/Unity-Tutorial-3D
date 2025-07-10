using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Shuffle : MonoBehaviour
{
    public int[] array = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

    public void Swap(int i, int j)
    {
        var temp = array[i];
        array[i] = array[j];
        array[j] = temp;
    }

    private void ShuffleFunction()
    {
        for (int i = 0; i < 200; i++)
        {
            int ranInt1 = Random.Range(0, array.Length), ranInt2 = Random.Range(0, array.Length);
            Swap(ranInt1, ranInt2);
        }
    }

    private void Start()
    {
        ShuffleFunction();
    }
}
