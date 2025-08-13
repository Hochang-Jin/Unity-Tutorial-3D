using System;
using Farm;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    private Crop crop;
    [SerializeField] private Image slotImage;
    [SerializeField] private Button slotButton;

    public bool isEmpty = true;

    private void Awake()
    {
        slotButton.onClick.AddListener(UseCrop);
    }

    private void OnEnable()
    {
        slotImage.gameObject.SetActive(!isEmpty);
        slotButton.interactable = !isEmpty;
    }

    public void AddCrop(Crop crop)
    {
        isEmpty = false;
        
        this.crop = crop;
        slotImage.sprite = crop.icon;
        
        slotImage.gameObject.SetActive(true);
        slotButton.interactable = true;
    }

    public void UseCrop()
    {
        Debug.Log("use 1");
        if (crop != null)
        {
            Debug.Log("use 2");
            crop.Use();
            isEmpty = true;
            slotButton.interactable = false;
            slotImage.gameObject.SetActive(false);
            GameManager.Instance.item.UseItem();
        }
    }
}
