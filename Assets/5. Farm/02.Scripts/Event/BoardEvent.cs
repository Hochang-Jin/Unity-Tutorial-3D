using System;
using Farm;
using UnityEngine;

public class BoardEvent : MonoBehaviour
{
    [SerializeField] private GameObject boardUI;
    [SerializeField] private GameObject singleBoard;
    [SerializeField] private GameObject aiBoard;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.SetCameraState(GameManager.CameraState.BOARD);
            boardUI.SetActive(true);
            SingleBoardController.startAction?.Invoke();
            BoardController.startAction?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.SetCameraState(GameManager.CameraState.HOUSE);
            boardUI.SetActive(false);
            singleBoard.SetActive(false);
            aiBoard.SetActive(false);
        }
    }
}
