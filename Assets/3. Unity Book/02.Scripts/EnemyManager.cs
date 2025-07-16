using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public float timer, targetTime;
    public GameObject enemyFactory;

    private void Start()
    {
        targetTime = Random.Range(1, 5);
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= targetTime)
        {
            timer = 0;
            GameObject enemy = Instantiate(enemyFactory);
            enemy.transform.position = transform.position;
        }
    }
}
