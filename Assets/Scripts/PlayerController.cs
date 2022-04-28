using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private StateMachine _stateMachine;
    private RunState _runState;
    private IdleState _idleState;

    [Header("Movement")]
    [SerializeField] private float _speed = 10f;

    public float Speed => _speed;

    private void Start()
    {
        _runState = new RunState(this);
        _idleState = new IdleState(this);
        _stateMachine = new StateMachine();
        _stateMachine.Initialize(_idleState);
    }

    private void Update()
    {
        _stateMachine.CurrentState.Update();

        Move();
    }

    private void Move()
    {
        float velocityX = Input.GetAxis("Horizontal");

        if (Mathf.Abs(velocityX) > 0)
        {
            _stateMachine.ChangeState(_runState);
        }
        else
        {
            _stateMachine.ChangeState(_idleState);
        }
    }
}
