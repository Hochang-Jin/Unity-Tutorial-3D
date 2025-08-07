using UnityEngine;

[CreateAssetMenu(fileName = "WeaponDataGroup", menuName = "Scriptable Objects/WeaponDataGroup")]
public class WeaponDataGroup : ScriptableObject
{
    public WData[] wData;
}

[System.Serializable]
public class WData
{
    public string name;
    public int damage;
    public float range;
}
