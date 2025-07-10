using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIHandler : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    private RectTransform parentRect;

    private Vector2 basePos;
    private Vector2 startPos;
    private Vector2 moveOffset;
    
    private void Awake()
    {
        parentRect = transform.parent.GetComponent<RectTransform>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        parentRect.SetAsLastSibling();// 최상위에 그려지도록 설정
        
        basePos = parentRect.anchoredPosition; // 기존 UI 의 위치
        startPos = eventData.position; // 시작점
    }

    public void OnDrag(PointerEventData eventData)
    {
        moveOffset = eventData.position - startPos;
        parentRect.anchoredPosition = basePos + moveOffset;
    }
}
