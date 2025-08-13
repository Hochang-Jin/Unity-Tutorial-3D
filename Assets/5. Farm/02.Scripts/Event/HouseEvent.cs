using System;
using Unity.Cinemachine;
using UnityEngine;

public class HouseEvent : MonoBehaviour
{
    [SerializeField] private GameObject houseTop;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        Farm.GameManager.Instance.SetCameraState(Farm.GameManager.CameraState.HOUSE);
        houseTop.SetActive(false);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        Farm.GameManager.Instance.SetCameraState(Farm.GameManager.CameraState.OUTSIDE);
        houseTop.SetActive(true);
    }
}
