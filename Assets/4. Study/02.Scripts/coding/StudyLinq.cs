using System;
using System.Linq;
using UnityEngine;

public class StudyLinq : MonoBehaviour
{
    public int[] numbers = { 1, 2, 3, 4, 5 };

    private void Start()
    {
        // var result = from number in numbers where number > 3 select number;
        // var result = numbers.Where(x => x > 3);

        // var result = from number in numbers select number * number;
        var result = numbers.Select(n => n * n); 
        
        foreach (var number in result)
            Debug.Log(number);
    }
}
