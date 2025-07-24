using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyFSM : MonoBehaviour
{
    private enum EnemyState { Idle, Move, Attack, Return, Damaged, Die }
    private EnemyState m_State;

    public float findDistance = 8f; // 탐지 거리
    private Transform player; // 타겟
    public float attackDistance = 3f; // 공격 가능 거리
    public float moveSpeed = 5f; // 이동 속도
    private CharacterController cc;
    
    private Animator anim;
    private NavMeshAgent smith;

    private float currentTime = 0f;
    private float attackDelay = 2f; // 공격 속도

    public int attackPower = 3;
    public int hp = 15;
    public int maxHp = 15;
    public Slider hpSlider;

    private Vector3 originPos;
    private Quaternion originRot;
    public float moveDistance = 20f;

    void Start()
    {
        m_State = EnemyState.Idle;
        player = GameObject.Find("Player").transform;
        cc = GetComponent<CharacterController>();
        originPos = transform.position;
        
        anim = transform.GetComponentInChildren<Animator>();
        smith = transform.GetComponentInChildren<NavMeshAgent>();
    }

    void Update()
    {
        switch (m_State)
        {
            case EnemyState.Idle:
                Idle();
                break;
            case EnemyState.Move:
                Move();
                break;
            case EnemyState.Attack:
                Attack();
                break;
            case EnemyState.Return:
                Return();
                break;
            // 이하 두 상태는 밑에서 따로 처리중
            case EnemyState.Damaged:
                // Damaged();
                break;
            case EnemyState.Die:
                // Die();
                break;
        }
        
        hpSlider.value = (float)hp / (float)maxHp;
    }

    private void Idle()
    {
        if (Vector3.Distance(transform.position, player.position) < findDistance)
        {
            m_State = EnemyState.Move;
            anim.SetTrigger("IdleToMove");
            Debug.Log("상태 전환 : Idle -> Move");
        }
    }

    private void Move()
    {
        if (Vector3.Distance(transform.position, originPos) > moveDistance)
        {
            m_State = EnemyState.Return;
            Debug.Log("상태 전환 : Move -> Return");
        }
        else if (Vector3.Distance(transform.position, player.position) > attackDistance) // 공격 거리 보다 멀면 이동
        {
            // Vector3 dir = (player.position - transform.position).normalized;
            //
            // cc.Move(dir * moveSpeed * Time.deltaTime);
            // transform.forward = dir; // 이동하려는 방향 바라보기

            smith.isStopped = true;
            smith.ResetPath();
            
            smith.stoppingDistance = attackDistance;
            smith.SetDestination(player.position);
        }
        else
        {
            currentTime = attackDelay; // 바로 공격 하게 하기
            anim.SetTrigger("MoveToAttackDelay");
            m_State = EnemyState.Attack;
            Debug.Log("상태 전환 : Move -> Attack");
        }
    }

    private void Attack()
    {
        if (Vector3.Distance(transform.position, player.position) < attackDistance) // 공격 범위 안
        {
            currentTime += Time.deltaTime;
            if (currentTime > attackDelay)
            {
                currentTime = 0f;
                // player.GetComponent<FPSPlayerMove>().DamageAction(attackPower);
                anim.SetTrigger("StartAttack");
                Debug.Log("공격");
            }
        }
        else // 공격 범위 밖
        {
            currentTime = 0f;
            m_State = EnemyState.Move;
            anim.SetTrigger("AttackToMove");
            Debug.Log("상태 전환 : Attack -> Move");
        }
    }

    public void AttackAction()
    {
        player.GetComponent<FPSPlayerMove>().DamageAction(attackPower);
    }

    private void Return()
    {
        if (Vector3.Distance(transform.position, originPos) > 0.1f) // 원래 위치로 복귀 중
        {
            // Vector3 dir = (originPos - transform.position).normalized;
            // cc.Move(dir * moveSpeed * Time.deltaTime);
            // transform.forward = dir;
            
            smith.SetDestination(originPos);
            smith.stoppingDistance = 0f;
            
        }
        else
        {
            smith.isStopped = true;
            smith.ResetPath();
            
            transform.position = originPos; // 위치 보정
            transform.rotation = originRot;
            hp = 15;
            m_State = EnemyState.Idle;
            anim.SetTrigger("MoveToIdle");
            Debug.Log("상태 전환 : Return -> Idle");
        }
    }

    public void HitEnemy(int damage)
    {
        if (m_State == EnemyState.Damaged || m_State == EnemyState.Die || m_State == EnemyState.Return)
            return;
        
        hp -= damage;

        smith.isStopped = true;
        smith.ResetPath();

        if (hp > 0) // 공격을 받고 살았다면
        {
            anim.SetTrigger("Damaged");
            m_State = EnemyState.Damaged;
            Debug.Log("상태 전환 : Any State -> Damaged");
            Damaged();
        }
        else // 공격을 받고 죽었다면
        {
            m_State = EnemyState.Die;
            Die();
            Debug.Log("상태 전환 : Any State -> Die");
        }
}

    private void Damaged()
    {
        StartCoroutine(DamageProcess());
    }

    IEnumerator DamageProcess()
    {
        yield return new WaitForSeconds(1f); // 애니메이션 시간만큼 대기

        m_State = EnemyState.Move;
        Debug.Log("상태 전환 : Damaged -> Move");
    }

    private void Die()
    {
        StopAllCoroutines();

        StartCoroutine(DieProcess());
    }

    IEnumerator DieProcess()
    {
        cc.enabled = false;
        anim.SetTrigger("Die");
        yield return new WaitForSeconds(2f);
        Debug.Log("소멸");
        Destroy(gameObject);
    }
}