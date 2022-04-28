using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    private PlayerController _player;
    private Animator _playerAnimator;
    private Rigidbody2D _playerRigidbody;

    public IdleState(PlayerController player)
    {
        _player = player;
        _playerAnimator = _player.GetComponent<Animator>();
        _playerRigidbody = _player.GetComponent<Rigidbody2D>();
    }

    public override void Enter()
    {
        base.Enter();
        _playerRigidbody.velocity = Vector2.zero;
        _playerAnimator.SetBool("isRunning", false);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
    }
}
