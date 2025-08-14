using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class AnimalController : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator anim;
    
    [SerializeField] private float wanderRadius = 15f;

    private float minWaitTime = 1f;
    private float maxWaitTime = 5f;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    private IEnumerator Start()
    {
        while (true)
        {
            // 랜덤 목적지 설정
            SetRandomDestination();
            // 애니메이션 변경 
            anim.SetBool("isWalk", true);
            // 목적지 도착할 때 까지 대기
            yield return new WaitUntil(() => !agent.pathPending && agent.remainingDistance <= agent.stoppingDistance);
            // 목적지 도착 후 애니메이션 변경
            anim.SetBool("isWalk", false);
            
            float idleTime = Random.Range(minWaitTime, maxWaitTime);
            yield return new WaitForSeconds(idleTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AnimalEvent.failAction?.Invoke();

            Debug.Log("동물 피하기 실패");
        }
    }
    
    void SetRandomDestination()
    {
        var randomDir = Random.insideUnitSphere * wanderRadius;
        randomDir += transform.position;
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomDir, out hit, wanderRadius, NavMesh.AllAreas))
        {
            agent.SetDestination(hit.position);
        }
    }
}
