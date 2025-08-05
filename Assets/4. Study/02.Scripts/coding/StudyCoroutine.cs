using System;
using System.Collections;
using UnityEngine;

public class StudyCoroutine : MonoBehaviour
{
    private IEnumerator enumerator;
    private void Start()
    {
        enumerator = Numbers();
    }

    private void Update()
    {
        // 수동 실행
        if (Input.GetKeyDown(KeyCode.Space))
        {
            enumerator.MoveNext();
            var current = enumerator.Current;
            Debug.Log(current);
        }
    }

    IEnumerator Numbers()
    {
        yield return 3;
        yield return 5;
        yield return 7;
    }
}
