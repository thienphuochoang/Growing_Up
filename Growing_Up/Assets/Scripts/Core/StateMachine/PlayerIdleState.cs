using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerState
{
    public PlayerIdleState(Player inputPlayer, PlayerStateMachine inputPlayerStateMachine, string inputAnimBoolName) : base(inputPlayer, inputPlayerStateMachine, inputAnimBoolName)
    {
    }

    public override void BeginState()
    {
        base.BeginState();
        player.ResetVelocity();
    }

    public override void UpdateState()
    {
        base.UpdateState();
        if (horizontalInput != 0)
            stateMachine.ChangeState(player.moveState);
        /*if (rb.velocity.y < 0)
            stateMachine.ChangeState(player.airState);*/
    }
}