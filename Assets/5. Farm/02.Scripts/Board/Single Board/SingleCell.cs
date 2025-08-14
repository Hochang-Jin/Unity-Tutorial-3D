using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SingleCell : MonoBehaviour
{
    public int x, y;
    [SerializeField] private Button button;
    [SerializeField] private TextMeshProUGUI cellText;
    
    public void SetText(string text)
    {
        cellText.text = text;
    }

    public void SetButton(int x, int y, Action <int, int> action)
    {
        this.x = x;
        this.y = y;
        
        button.onClick.AddListener(() => action(x,y));
    }
}
