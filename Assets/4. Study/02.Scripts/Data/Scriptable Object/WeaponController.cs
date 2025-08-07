using System;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public WeaponData[] weaponDatas;

    private void Start()
    {
        foreach (var data in weaponDatas)
        {
            Debug.Log($"{data.name} / {data.damage} / {data.range} ");
        }
    }
}
