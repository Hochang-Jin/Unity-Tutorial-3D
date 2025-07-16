using System;
using UnityEngine;

public class LocalData : MonoBehaviour
{
    private int score;
    void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            score++;
            // 로컬에 데이터 저장
            PlayerPrefs.SetInt("score", score);
        }
    }
}
