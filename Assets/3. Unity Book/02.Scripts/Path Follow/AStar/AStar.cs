using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AStar
{
    public static PriorityQueue openList; // 방문 가능한 후보 노드
    public static PriorityQueue closedList; // 이미 방문한 노드

    private static float HeuristicEstimateCost(Node curNode, Node endNode)
    {
        Vector3 cost = curNode.pos - endNode.pos;
        
        return cost.magnitude;
    }

    public static List<Node> FindPath(Node start, Node end)
    {
        openList = new PriorityQueue();
        openList.Push(start);
        start.nodeTotalCost = 0f;
        start.estimateCost = HeuristicEstimateCost(start, end);
        closedList = new PriorityQueue();
        Node node = null;

        while (openList.Length != 0)
        {
            node = openList.First();
            if (node.pos == end.pos)
            {
                return CalculatePath(node);
            }
            
            List<Node> neighbors = new List<Node>();
            GridManager.Instance.GetNeighbors(node, neighbors);

            for (int i = 0; i < neighbors.Count; i++)
            {
                Node neighbor = neighbors[i];
                if (!closedList.Contains(neighbor))
                {
                    float cost = HeuristicEstimateCost(node, neighbor);
                    float totalCost = node.nodeTotalCost + cost;
                    
                    float neighborNodeEstCost = HeuristicEstimateCost(neighbor, end);
                    
                    neighbor.nodeTotalCost = totalCost;
                    neighbor.parent = node;
                    neighbor.estimateCost = totalCost + neighborNodeEstCost;

                    if (!openList.Contains(neighbor))
                    {
                        openList.Push(neighbor);
                    }
                }
            }
            
            closedList.Push(node);
            openList.Remove(node);
        }

        if (node.pos != end.pos)
        {
            Debug.LogError("Destination Path Not Found");
            return null;
        }

        return CalculatePath(node);
    }

    private static List<Node> CalculatePath(Node node)
    {
        List<Node> list = new List<Node>();
        while (node != null)
        {
            list.Add(node);
            node = node.parent;
            
        }
        
        list.Reverse();
        return list;
    }
    
}
