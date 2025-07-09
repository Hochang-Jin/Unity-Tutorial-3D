using System.Collections;
using UnityEngine;

public class HanoiTower : MonoBehaviour
{
    public enum HanoiLevel {Lv1=3, Lv2, Lv3}
    public HanoiLevel hanoiLevel;

    public static GameObject selectedDonut;
    public static bool isSelected;
    
    public GameObject[] donutPrefabs;
    public BoardBar[] bars;
    

    private IEnumerator Start()
    {
        for (int i = (int)hanoiLevel - 1; i >= 0; i--)
        {
            GameObject donut = Instantiate(donutPrefabs[i]);
            donut.transform.position = new Vector3(-5, 8, 0); // 도넛 생성 위치 : 왼쪽 바
            bars[0].PushDonut(donut);
            
            yield return new WaitForSeconds(1f);
        }
    }
}
