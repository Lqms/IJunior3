using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private StateMachine _stateMachine;
    private RunState _runState;
    private IdleState _idleState;
    private JumpState _jumpState;
    private State _currentState;

    [Header("Movement")]
    [SerializeField] private float _speed = 10f;

    [Header("Jump")]
    [SerializeField] private float _jumpPower = 2f;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private float _legsDistance = 0.4f;
    [SerializeField] private Transform _legs;

    public float Speed => _speed;
    public float JumpPower => _jumpPower;

    private void Start()
    {
        _runState = new RunState(this);
        _idleState = new IdleState(this);
        _jumpState = new JumpState(this);
        _stateMachine = new StateMachine();
        _stateMachine.Initialize(_idleState);
        _currentState = _idleState;
    }

    private void Update()
    {
        _stateMachine.CurrentState.Update();

        Move();
        Jump();
    }

    private void Move()
    {
        float velocityX = Input.GetAxis("Horizontal");

        if (Mathf.Abs(velocityX) > 0 && _currentState != _runState)
        {
            _stateMachine.ChangeState(_runState);
            _currentState = _runState;
        }
        else
        {
            if (_currentState != _idleState)
            {
                _stateMachine.ChangeState(_idleState);
                _currentState= _idleState;
            }
        }
    }

    private void Jump()
    {
        float velocityY = Input.GetAxis("Jump");

        if (velocityY > 0)
        {
            _stateMachine.ChangeState(_jumpState);
        }

        if (Physics.CheckSphere(_legs.position, _legsDistance, _groundMask))
        {
            Debug.Log("Grounded");
            _stateMachine.ChangeState(_idleState);
        }
    }
}
