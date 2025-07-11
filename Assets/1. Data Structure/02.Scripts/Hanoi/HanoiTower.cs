using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HanoiTower : MonoBehaviour
{
    public enum HanoiLevel {Lv1=3, Lv2, Lv3}
    public HanoiLevel hanoiLevel = HanoiLevel.Lv1;

    public static GameObject selectedDonut;
    public static bool isSelected;
    public static BoardBar currBar;
    private bool check;
    
    public TextMeshProUGUI countText;
    public Button answerButton;
    
    public GameObject[] donutPrefabs;
    public BoardBar[] bars;
    public static int moveCount;

    private void Awake()
    {
        answerButton.onClick.AddListener(HanoiAnswer);
    }

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

    private void HanoiAnswer()
    {
        StartCoroutine(HanoiRoutine((int)hanoiLevel, 0, 1, 2));
    }

    IEnumerator HanoiRoutine(int n, int from, int temp, int to)
    {
        if (n == 1)
        {
            Debug.Log($"{n}번 도넛을 {from}에서 {to}로 이동");
            yield return new WaitForSeconds(0.5f);
            selectedDonut = bars[from].PopDonut();
            bars[to].PushDonut(selectedDonut);
            
        }
        else
        {
            yield return StartCoroutine(HanoiRoutine(n-1, from, to, temp));
            Debug.Log($"{n}번 도넛을 {from}에서 {to}로 이동");
            yield return new WaitForSeconds(0.5f);
            selectedDonut = bars[from].PopDonut();
            bars[to].PushDonut(selectedDonut);
            

            yield return StartCoroutine(HanoiRoutine(n - 1, temp, from, to));
        }
        
    }
    
}
