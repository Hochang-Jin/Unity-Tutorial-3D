using UnityEngine;

public class Factorial : MonoBehaviour
{
    public int n;
    void Start()
    {
        Debug.Log(FactorialFunction(n));
    }

    public int FactorialFunction(int n)
    {
        if (n == 0) return 1;
        else return n * FactorialFunction(n - 1);
    }
}
