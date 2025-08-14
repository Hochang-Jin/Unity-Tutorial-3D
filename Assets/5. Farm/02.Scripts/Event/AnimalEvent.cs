using System;
using Unity.Cinemachine;
using UnityEngine;
using Random = UnityEngine.Random;

public class AnimalEvent : MonoBehaviour
{
    [SerializeField] private GameObject flag;
    private BoxCollider boxCollider;

    private float timer;
    private bool isTimer;

    public static Action failAction;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        failAction += SetRandomFlagPos;
    }

    private void Update()
    {
        if (!isTimer) return;
        timer += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        SetRandomFlagPos();
        
        if (!other.CompareTag("Player")) return;
        Farm.GameManager.Instance.SetCameraState(Farm.GameManager.CameraState.ANIMAL);
        isTimer = true;
    }

    private void OnTriggerExit(Collider other)
    {
        SetFlag(Vector3.zero, false);
        
        if (!other.CompareTag("Player")) return;
        Farm.GameManager.Instance.SetCameraState(Farm.GameManager.CameraState.OUTSIDE);
        Debug.Log($"깃발 찾는 데 걸린 시간은 {timer:f1} 초 입니다.");
        isTimer = false;
        timer = 0;
    }

    private void SetRandomFlagPos()
    {
        float randomX = Random.Range(boxCollider.bounds.min.x, boxCollider.bounds.max.x);
        float randomZ = Random.Range(boxCollider.bounds.min.z, boxCollider.bounds.max.z);
        Vector3 randomPos = new Vector3(randomX, 0, randomZ);
        
        SetFlag(randomPos, true);
    }

    private void SetFlag(Vector3 position, bool isActive)
    {
        flag.transform.SetParent(transform);
        flag.transform.position = position;
        flag.SetActive(isActive);
    }
}