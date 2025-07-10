using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class HanoiTower : MonoBehaviour
{
    public enum HanoiLevel {Lv1=3, Lv2, Lv3}
    public HanoiLevel hanoiLevel;

    public static GameObject selectedDonut;
    public static bool isSelected;
    public static BoardBar currBar;
    
    public TextMeshProUGUI countText;
    
    public GameObject[] donutPrefabs;
    public BoardBar[] bars;
    public static int moveCount;
    

    private IEnumerator Start()
    {
        for (int i = (int)hanoiLevel - 1; i >= 0; i--)
        {
            GameObject donut = Instantiate(donutPrefabs[i]);
            donut.transform.position = new Vector3(-5, 8, 0); // 도넛 생성 위치 : 왼쪽 바
            bars[0].PushDonut(donut);
            
            yield return new WaitForSeconds(1f);
        }
        moveCount = 0;
        countText.text = moveCount.ToString();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            currBar.barStack.Push(selectedDonut);
            isSelected = false;
            selectedDonut = null;
        }
        
        countText.text = moveCount.ToString();
    }
}
