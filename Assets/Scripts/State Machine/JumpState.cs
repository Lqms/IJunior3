using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : State
{
    private PlayerController _player;
    private Animator _playerAnimator;
    private Rigidbody2D _playerRigidbody;

    public JumpState(PlayerController player)
    {
        _player = player;
        _playerAnimator = _player.GetComponent<Animator>();
        _playerRigidbody = _player.GetComponent<Rigidbody2D>();
    }

    public override void Enter()
    {
        base.Enter();
        _playerRigidbody.AddForce(Vector2.up * _player.Speed * _player.JumpPower, ForceMode2D.Impulse);
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
