using System.Collections;
using UnityEngine;

public class BombSpawaner : MonoBehaviour
{
    public GameObject bombPrefap;
    public Vector2 range = new Vector2(5, 5);

    IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            BombSpawn();
        }
    }

    private void BombSpawn()
    {
        Vector2 ranRange = new Vector2(Random.Range(-range.x, range.x + 1), Random.Range(-range.y, range.y + 1));
        
        Vector3 ranPos = new Vector3(ranRange.x, 10f, ranRange.y);
        Instantiate(bombPrefap, ranPos, Quaternion.identity);
    }
}
