using UnityEngine;

public class SaveService : MonoBehaviour, ISaveService
{
    public void SaveData()
    {
        UnityEngine.Debug.Log("save DAta");
    }

    public void LoadData()
    {
        UnityEngine.Debug.Log("load data");
    }
}
