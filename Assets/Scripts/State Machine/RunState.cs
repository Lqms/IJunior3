using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : State
{
    private PlayerController _player;
    private Animator _playerAnimator;
    private SpriteRenderer _playerSpriteRenderer;
    private Rigidbody2D _playerRigidbody;
    private float _playerSpeed;

    public RunState(PlayerController player)
    {
        _player = player;
        _playerAnimator = _player.GetComponent<Animator>();
        _playerSpriteRenderer = _player.GetComponent<SpriteRenderer>();
        _playerRigidbody = _player.GetComponent<Rigidbody2D>();
        _playerSpeed = _player.Speed;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        float velocityX = Input.GetAxis("Horizontal");
        _playerRigidbody.velocity = new Vector2(_playerSpeed * velocityX, 0);
        _playerAnimator.SetBool("isRunning", true);
        _playerSpriteRenderer.flipX = velocityX < 0;
    }
}
