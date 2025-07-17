using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    private Vector3 dir;
    public float speed = 5;
    public GameObject explosionFactory;
    
    private void OnEnable()
    {
        int ranValue = Random.Range(0, 10);
        if (ranValue < 3)
        {
            GameObject target = GameObject.Find("Player");
            dir = target.transform.position - transform.position;
            dir.Normalize();
        }
        else
        {
            dir = Vector3.down;
        }
    }

    private void Update()
    {
        transform.position += dir * (Time.deltaTime * speed);
    }

    public void OnCollisionEnter(Collision other)
    {
        // GameObject smObject = GameObject.Find("ScoreManager");
        // ScoreManager sm =  smObject.GetComponent<ScoreManager>();
        // int score = sm.GetScore() + 1;
        // sm.SetScore(score);
        
        // 위의 4줄이 싱글턴 사용으로 한줄로 줄었음
        ScoreManager.Instance.Score++;
        
        GameObject explosion = Instantiate(explosionFactory);
        explosion.transform.position = transform.position;
        
        // Destroy(other.gameObject);
        if(other.gameObject.name.Contains("Bullet"))
        {
            PlayerFire.Instance.bulletObjectPool.Add(other.gameObject);
            other.gameObject.SetActive(false);
            // other.gameObject.SetActive(false);
        }
        else
        {
            Destroy(other.gameObject);
        }
        EnemyManager.Instance.enemyObjectPool.Add(gameObject);
        gameObject.SetActive(false);
    }
}
