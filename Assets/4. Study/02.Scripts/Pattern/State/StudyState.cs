using System;
using UnityEngine;

public class StudyState : MonoBehaviour
{
    private IState idleState, moveState, attackState;
    public IState state;

    private void Awake()
    {
        idleState = gameObject.AddComponent<IdleState>();
        moveState = gameObject.AddComponent<MoveState>();
        attackState = gameObject.AddComponent<AttackState>();
        
        state = idleState;
    }

    private void Start()
    {
        state.StateEnter();
    }

    private void OnDestroy()
    {
        state.StateExit();
    }

    private void Update()
    {
        state?.StateUpdate();
        
       if(Input.GetKeyDown(KeyCode.Alpha1))
           SetState(new IdleState());
       else if(Input.GetKeyDown(KeyCode.Alpha2))
           SetState(new AttackState());
       else if(Input.GetKeyDown(KeyCode.Alpha3))
           SetState(new MoveState());
    }

    public void SetState(IState newState)
    {
        if (newState == state) return;
        state?.StateExit();
        state = newState;
        state?.StateEnter();
        
    }
}
