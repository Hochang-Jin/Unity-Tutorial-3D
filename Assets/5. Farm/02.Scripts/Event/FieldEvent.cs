using System;
using Farm;
    
using Unity.Cinemachine;
using UnityEngine;

public class FieldEvent : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.SetCameraState(Farm.GameManager.CameraState.FIELD);
            GameManager.Instance.ui.ActivateFieldUI(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.SetCameraState(GameManager.CameraState.OUTSIDE);
            GameManager.Instance.ui.ActivateFieldUI(false);
        }
    }
}