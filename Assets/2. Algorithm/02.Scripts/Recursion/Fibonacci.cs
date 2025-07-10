using System;
using UnityEngine;

public class Fibonacci : MonoBehaviour
{
    public int fibonacci;
    private void Start()
    {
        Debug.Log(FibonacciFunction(fibonacci));
    }

    private int FibonacciFunction(int n)
    {
        if (n < 2) return n;
        return FibonacciFunction(n - 1) + FibonacciFunction(n - 2);
    }
}
