using System;
using UnityEngine;
using UnityEngine.AI;

public class AgentController : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent agent;

    public Transform[] points;
    public int index;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        agent.SetDestination(points[index].position);
        if (agent.remainingDistance <= 1.5f) // 목적지와의 거리가 1.5 이하일 경우
        {
            Debug.Log($"{index++}");
            if(index >= points.Length)
                index = 0;
        }
    }
}
