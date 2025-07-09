using System;
using System.Collections.Generic;
using UnityEngine;

public class BoardBar : MonoBehaviour
{
    public enum BarType
    {
        LEFT,
        CENTER,
        RIGHT
    }
    public BarType barType;
    
    public Stack<GameObject> barStack = new Stack<GameObject>();

    private void OnMouseDown()
    {
        if (!HanoiTower.isSelected)
        {
            HanoiTower.isSelected = true;
            HanoiTower.selectedDonut = PopDonut();
        }
        else
        {
            PushDonut(HanoiTower.selectedDonut);
        }
    }

    public bool CheckDonut(GameObject donut)
    {
        if (barStack.Count > 0) // 현재 바에 도넛이 하나라도 있으면 
        {
            int pushNumber = donut.GetComponent<Donut>().donutNumber;
            int peekNumber = barStack.Peek().GetComponent<Donut>().donutNumber;

            if (pushNumber < peekNumber) // 넣을게 현재 바의 맨 위에있는 것 보다 작다면
                return true;
            else
            {
                return false;
            }
        }

        return true; // 현재 바에 아무것도 없을 때는 도넛을 넣을 수 있음
    }

    public void PushDonut(GameObject donut)
    {
        if (!CheckDonut(donut)) return;
        
        HanoiTower.selectedDonut = null;
        HanoiTower.isSelected = false;
        
        donut.transform.position = this.transform.position + Vector3.up * 5f;
        donut.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
        donut.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        
        barStack.Push(donut);
    }

    public GameObject PopDonut()
    {
        return barStack.Pop();
    }
}
