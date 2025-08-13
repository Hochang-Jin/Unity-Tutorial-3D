using System;
using Unity.Cinemachine;
using UnityEngine;

public class AnimalEvent : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        Farm.GameManager.Instance.SetCameraState(Farm.GameManager.CameraState.ANIMAL);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        Farm.GameManager.Instance.SetCameraState(Farm.GameManager.CameraState.OUTSIDE);
    }
}