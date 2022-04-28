using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{

    private PlayerController _player;

    public IdleState(PlayerController player)
    {
        _player = player;
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
    }
}
