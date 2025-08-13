using System;
using Farm;
using UnityEngine;

public class Crop : MonoBehaviour
{
    [SerializeField] private string name;
    public Sprite icon;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Get();
            
        }
    }

    /// <summary>
    /// 인벤토리에 작물 추가
    /// </summary>
    public void Get()
    {
        if (GameManager.Instance.item.CheckItemCount())
        {
            GameManager.Instance.item.GetItem(this);
            Debug.Log($"{name} 획득 했습니다.");
            gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("인벤토리가 가득 찼습니다.");
        }
    }

    /// <summary>
    /// 체력이나 스테미너를 회복
    /// 인벤토리에서 버튼을 눌렀을 때 실행되는 기능
    /// </summary>
    public void Use()
    {
        Debug.Log($"{name} 사용쓰");
    }
}
