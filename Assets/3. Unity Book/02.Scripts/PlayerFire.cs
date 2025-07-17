using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : Singleton<PlayerFire>
{
    public GameObject bulletFactory;
    public GameObject firePosition;

    public int poolSize = 10;
    // public GameObject[] bulletObjectPool;

    public List<GameObject> bulletObjectPool;
    private void Start()
    {
        bulletObjectPool = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletFactory);
            bulletObjectPool.Add(bullet);
            bullet.SetActive(false);
        }
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (bulletObjectPool.Count > 0)
            {
                GameObject bullet = bulletObjectPool[0];
                bullet.SetActive(true);
                
                bulletObjectPool.Remove(bullet);
                bullet.transform.position = firePosition.transform.position;
            }
            
            
            // for (int i = 0; i < poolSize; i++)
            // {
            //     GameObject bullet = bulletObjectPool[i];
            //
            //     if (!bullet.activeSelf)
            //     {
            //         bullet.SetActive(true);
            //         bullet.transform.position = firePosition.transform.position;
            //         
            //         break;
            //     }
            // }
        }
    }
}
