using System;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public GameObject[] obstacles;
    public Node[,]  nodes { get; set; }

    public int numOfRows;
    public int numOfCols;
    public float gridCellSize;

    private Vector3 origin = new Vector3();

    public Vector3 Origin
    {
        get { return origin; }
    }

    private void Awake()
    {
        obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
    }

    private void CalculateObstacles()
    {
        nodes = new Node[numOfRows, numOfCols];
        int index = 0;
        for (int i = 0; i < numOfRows; i++)
        {
            for (int j = 0; j < numOfCols; j++)
            {
                Vector3 cellPos = GetGridCellCenter(index++);
                Node node = new Node(cellPos);
                nodes[i, j] = node;
            }
        }

        if (obstacles != null && obstacles.Length > 0)
        {
            foreach (var obstacle in obstacles)
            {
                int indexCell = GetGridIndex(obstacle.transform.position);
                GetRowCol(indexCell, out var row, out var col);
                nodes[row, col].MarkAsObstacle();
            }
        }
    }

    public Vector3 GetGridCellCenter(int index)
    {
        Vector3 cellPos = GetGridCellPosition(index);
        cellPos.x += gridCellSize / 2f;
        cellPos.y += gridCellSize / 2f;
        return cellPos;
    }

    public Vector3 GetGridCellPosition(int index)
    {
        GetRowCol(index, out var row, out var col);
        
        float xPosInGrid = col * gridCellSize;
        float zPosInGrid = row * gridCellSize;
        
        return Origin + new Vector3(xPosInGrid, 0.0f, zPosInGrid);
    }

    public int GetGridIndex(Vector3 pos)
    {
        if (!isInBounds(pos))
            return -1;
        pos += Origin;
        int col = (int)(pos.x / gridCellSize);
        int row = (int)(pos.z / gridCellSize);
        
        return col * numOfCols + row;
    }

    public bool isInBounds(Vector3 pos)
    {
        float width = numOfCols * gridCellSize;
        float height = numOfRows * gridCellSize;
        
        return pos.x >= Origin.x && pos.x <= Origin.x + width && pos.z >= Origin.z && pos.z <= Origin.z + height;
    }

    public void GetRowCol(int index, out int row, out int col)
    {
        row = index / numOfCols;
        col = index % numOfCols;
    }

    public void GetNeighbors(Node node, List<Node> neighbors)
    {
        int nodeIndex = GetGridIndex(node.pos);
        GetRowCol(nodeIndex, out var row, out var col);
        
        // down
        int leftNodeRow = row - 1;
        int leftNodeCol = col;
        AssignNeighbor(leftNodeRow, leftNodeCol, neighbors);
        // up
        leftNodeRow = row + 1;
        leftNodeCol = col;
        AssignNeighbor(leftNodeRow, leftNodeCol, neighbors);
        // right
        leftNodeRow = row;
        leftNodeCol = col + 1;
        AssignNeighbor(leftNodeRow, leftNodeCol, neighbors);
        // left
        leftNodeRow = row;
        leftNodeCol = col - 1;
        AssignNeighbor(leftNodeRow, leftNodeCol, neighbors);
    }

    private void AssignNeighbor(int row, int col, List<Node> neighbors)
    {
        if (row != -1 && col != -1 && row < numOfRows && col < numOfCols)
        {
            Node nodeToAdd = nodes[row, col];
            if(!nodeToAdd.isObstacle)
                neighbors.Add(nodeToAdd);
        }
    }

    private void OnDrawGizmos()
    {
        DebugDrawGrid(transform.position, numOfRows, numOfCols, gridCellSize, Color.blue);
    }

    public void DebugDrawGrid(Vector3 origin, int numOfRows, int numOfCols, float cellSize, Color color)
    {
        float width = numOfCols * gridCellSize;
        float height = numOfRows * gridCellSize;

        for (int i = 0; i < numOfRows; i++)
        {
            Vector3 startPos = origin + i * cellSize * Vector3.forward;
            Vector3 endPos = startPos + width * Vector3.right;
            Debug.DrawLine(startPos, endPos, color);
        }

        for (int i = 0; i < numOfCols; i++)
        {
            Vector3 startPos = origin + i * cellSize * Vector3.right;
            Vector3 endPos = startPos + height * Vector3.forward;
            Debug.DrawLine(startPos, endPos, color);
        }
        
    }
}
