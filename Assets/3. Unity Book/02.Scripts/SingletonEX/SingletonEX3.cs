using UnityEngine;

public class SingletonEX3 : MonoBehaviour
{
    private static SingletonEX3 instance;

    public static SingletonEX3 Instance
    {
        get
        {
            if(instance == null)
                instance = new SingletonEX3();
            
            return instance;
        }
    }
}
