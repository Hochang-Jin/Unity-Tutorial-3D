using System;
using UnityEngine;
using UnityEngine.UI;

namespace Farm
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private GameObject outSideUI;
        [SerializeField] private GameObject fieldUI;
        [SerializeField] private GameObject houseUI;
        [SerializeField] private GameObject animalUI;
        [SerializeField] private GameObject seedUI;
        [SerializeField] private GameObject inventoryUI;

        [SerializeField] private Button seedButton;
        [SerializeField] private Button harvestButton;
        [SerializeField] private Button[] plantButtons;

        void Awake()
        {
            seedButton.onClick.AddListener(OnSeedButton);
            harvestButton.onClick.AddListener(OnHarvestButton);

            for (int i = 0; i < plantButtons.Length; i++)
            {
                int j = i;
                plantButtons[i].onClick.AddListener(() => GameManager.Instance.field.SetPlant(j));
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                inventoryUI.SetActive(!inventoryUI.activeSelf);
            }
        }

        private void OnSeedButton()
        {
            GameManager.Instance.field.SetState(FieldManager.FieldState.Seed);
            seedUI.SetActive(true);
        }

        private void OnHarvestButton()
        {
            GameManager.Instance.field.SetState(FieldManager.FieldState.Harvest);
            seedUI.SetActive(false);
        }

        public void ActivateFieldUI(bool isActive)
        {
            fieldUI.SetActive(isActive);
        }
    }
}