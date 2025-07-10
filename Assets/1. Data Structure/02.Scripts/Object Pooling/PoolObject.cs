using System;
using UnityEngine;

public class PoolObject : MonoBehaviour
{
    private ObjectPoolQueue pool;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        pool = FindFirstObjectByType<ObjectPoolQueue>();
    }

    private void OnEnable()
    {
        Invoke(nameof(ReturnPool), 3f);
    }

    private void Update()
    {
        transform.position += Vector3.right * (Time.deltaTime * 10f);
    }

    private void ReturnPool()
    {
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        pool.EnqueueObject(gameObject);
    }
}
