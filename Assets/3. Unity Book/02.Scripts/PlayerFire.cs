using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : Singleton<PlayerFire>
{
    public GameObject bulletFactory;
    public GameObject firePosition;

    public int poolSize = 10;

    // public GameObject[] bulletObjectPool;
    // public List<GameObject> bulletObjectPool;
    public Queue<GameObject> bulletObjectPool;

    private void Start()
    {
        // bulletObjectPool = new GameObject[poolSize];
        // bulletObjectPool = new List<GameObject>();
        bulletObjectPool = new Queue<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletFactory);
            bulletObjectPool.Enqueue(bullet);
            bullet.SetActive(false);
        }
    }

    private void Update()
    {
#if UNITY_STANDALONE
        if (Input.GetButtonDown("Fire1"))
        {
            if (bulletObjectPool.Count > 0)
            {
                GameObject bullet = bulletObjectPool.Dequeue();
                bullet.SetActive(true);
                bullet.transform.position = firePosition.transform.position;
            }
        }
#endif
    }
}
