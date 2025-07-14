using UnityEngine;

public class DijkstraSearch : MonoBehaviour
{
    private int[,] nodes = new int[6, 6]
    {
        //0  1  2  3  4  5
        { 0, 1, 2, 0, 4, 0 }, // 0
        { 1, 0, 0, 0, 0, 8 }, // 1
        { 2, 0, 0, 3, 0, 0 }, // 2
        { 0, 0, 3, 0, 0, 0 }, // 3
        { 4, 0, 0, 0, 0, 2 }, // 4
        { 0, 8, 0, 0, 2, 0 }, // 5
    };
    void Start()
    {
        int start = 0;
        int[] dist;
        int[] prev;
        Dijkstra(start, out dist, out prev);

        for (int i = 0; i < nodes.GetLength(0); i++)
        {
            Debug.Log($"{start} 에서 {i} 까지 최단 거리 : {dist[i]}, 경로 : {GetPath(i, prev)}");
        }
    }

    private void Dijkstra(int start, out int[] dist, out int[] prev)
    {
        int n = nodes.GetLength(0);
        dist = new int[n];
        prev = new int[n];
        bool[] visited = new bool[n];

        // 지역변수 초기화
        for (int i = 0; i < n; i++)
        {
            dist[i] = int.MaxValue;
            prev[i] = -1;
            visited[i] = false;
        }
        
        dist[start] = 0;
        for (int cnt = 0; cnt < n; cnt++)
        {
            int u = -1; // 최단거리 노드
            int min = int.MaxValue; // 최단 거리
            
            // 방문하지 않은 노드 중 최소 거리 노드 선택
            for (int i = 0; i < n; i++)
            {
                if (!visited[i] && dist[i] < min)
                {
                    min = dist[i];
                    u = i;
                }
            }
            
            if(u == -1) break; // 더이상 최단 거리 노드 없음
            
            visited[u] = true;
            for (int i = 0; i < n; i++)
            {
                if (nodes[u, i] > 0)
                {
                    int newDist = dist[u] + nodes[u, i];
                    if (newDist < dist[i])
                    {
                        dist[i] = newDist;
                        prev[i] = u;
                    }
                }
            }
        }
    }

    public string GetPath(int end, int[] prev)
    {
        if(prev[end] == -1)
            return end.ToString();

        return $"{GetPath(prev[end], prev)} -> {end.ToString()}";
    }
}
