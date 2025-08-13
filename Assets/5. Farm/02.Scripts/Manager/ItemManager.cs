using System;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField] private Transform slotGroup;
    [SerializeField] private Slot[] slots;
    [SerializeField] private GameObject slotPrefab;
    [SerializeField] private int slotAmount = 15;
    
    public List<GameObject> items = new List<GameObject>();
    private int itemCount = 0;


    private void Start()
    {
        for (int i = 0; i < slotAmount; i++)
        {
            GameObject slot = Instantiate(slotPrefab, slotGroup);
        }

        slots = slotGroup.GetComponentsInChildren<Slot>();
    }

    /// <summary>
    /// 빈 슬롯이 있다면
    /// 그 슬롯에 해당 Crop 데이터를 저장
    /// </summary>
    /// <param name="crop"></param>
    public void GetItem(Crop crop)
    {
        foreach (var slot in slots)
        {
            if (slot.isEmpty)
            {
                slot.AddCrop(crop);
                itemCount++;
                break;
            }
        }
    }

    /// <summary>
    /// 인벤토리가 다 찼는지 확인
    /// </summary>
    /// <returns>bool : 인벤토리에 아이템을 추가 할 수 있는지 여부</returns>
    public bool CheckItemCount()
    {
        bool result = itemCount <  slotAmount;
        return result;
    }

    public void UseItem()
    {
        itemCount--;
    }
}
