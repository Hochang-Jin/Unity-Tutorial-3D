using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : Singleton<EnemyManager>
{
    public int poolSize = 10;
    // public GameObject[] enemyObjectPool;
    // public List<GameObject> enemyObjectPool;
    public Queue<GameObject> enemyObjectPool;
    public Transform[] spawnPoints;
    
    public float timer, targetTime;
    public GameObject enemyFactory;

    private void Start()
    {
        targetTime = Random.Range(1, 5);
        
        enemyObjectPool = new Queue<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject enemy = Instantiate(enemyFactory);

            enemyObjectPool.Enqueue(enemy);
            enemy.SetActive(false);
        }
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= targetTime)
        {
            timer = 0;
            
            if(enemyObjectPool.Count > 0)
            {
                GameObject enemy = enemyObjectPool.Dequeue();
                
                int randIndex = Random.Range(0, spawnPoints.Length);
                enemy.transform.position = spawnPoints[randIndex].position;
                
                enemy.SetActive(true);
            }

            
            // for (int i = 0; i < poolSize; i++)
            // {
            //     
            //     GameObject enemy = enemyObjectPool[i];
            //     if (!enemy.activeSelf)
            //     {
            //         int randIndex = Random.Range(0, spawnPoints.Length);
            //         enemy.transform.position = spawnPoints[randIndex].position;
            //         enemy.SetActive(true);
            //     
            //         enemyObjectPool.Remove(enemy);
            //         
            //         break;
            //     }
            // }
        }
    }
}
