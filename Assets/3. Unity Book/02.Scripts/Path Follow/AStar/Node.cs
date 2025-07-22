using System;
using UnityEngine;

public class Node : IComparable<Node>
{
    public Node parent;
    public Vector3 pos;

    public float nodeTotalCost; // G (현재까지 진행한 최소거리)
    public float estimateCost; // H (남은 거리 예측)
    
    public bool isObstacle;

    public Node()
    {
        parent = null;
        nodeTotalCost = 0;
        estimateCost = 0;
        isObstacle = false;
    }

    public Node(Vector3 pos)
    {
        this.pos = pos;
        parent = null;
        nodeTotalCost = 0;
        estimateCost = 0;
        isObstacle = false;
    }

    public void MarkAsObstacle()
    {
        isObstacle = true;
    }

    public float GetFCost() // F = G + H
    {
        return nodeTotalCost + estimateCost;
    }

    public int CompareTo(Node other)
    {
        float myF = GetFCost();
        float otherF = other.GetFCost();

        if (myF < otherF) return -1;
        if (myF > otherF) return 1;
        
        if(estimateCost < otherF) return -1;
        if (estimateCost > otherF) return 1;
        return 0;
    }
}
