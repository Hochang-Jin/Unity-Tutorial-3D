using System;
using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name.Contains("Bullet"))
        {
            PlayerFire.Instance.bulletObjectPool.Add(other.gameObject);
            other.gameObject.SetActive(false);
        }
        else
        {
            EnemyManager.Instance.enemyObjectPool.Add(other.gameObject);
            other.gameObject.SetActive(false);
        }
    }
}
