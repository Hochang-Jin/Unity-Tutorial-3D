using System;
using UnityEngine;

public class GameFacade : MonoBehaviour
{
    private InventorySystem inventorySystem;
    private QuestSystem questSystem;
    private SoundSystem soundSystem;

    private void Awake()
    {
        inventorySystem = GetComponent<InventorySystem>();
        questSystem = GetComponent<QuestSystem>();
        soundSystem = GetComponent<SoundSystem>();
        
        if(inventorySystem == null)
            inventorySystem = gameObject.AddComponent<InventorySystem>();
        if (questSystem == null)
            questSystem = gameObject.AddComponent<QuestSystem>();
        if(soundSystem == null)
            soundSystem = gameObject.AddComponent<SoundSystem>();
    }

    public void ItemEvent(int index, string itemName)
    {
        switch (index)
        {
            case 0:
                inventorySystem.AddItem(itemName);
                break;
            case 1:
                inventorySystem.HasItem(itemName);
                break;
            case 2:
                inventorySystem.RemoveItem(itemName);
                break;
            default:
                Debug.LogError("에러");
                break;
        }
    }
    public void SoundEvent(int index, string soundName)
    {
        switch (index)
        {
            case 0:
                inventorySystem.AddItem(soundName);
                break;
            case 1:
                inventorySystem.HasItem(soundName);
                break;
            case 2:
                inventorySystem.RemoveItem(soundName);
                break;
            default:
                Debug.LogError("에러");
                break;
        }
    }
    public void QuestEvent(int index, string questName)
    {
        switch (index)
        {
            case 0:
                inventorySystem.AddItem(questName);
                break;
            case 1:
                inventorySystem.HasItem(questName);
                break;
            case 2:
                inventorySystem.RemoveItem(questName);
                break;
            default:
                Debug.LogError("에러");
                break;
        }
    }
}
