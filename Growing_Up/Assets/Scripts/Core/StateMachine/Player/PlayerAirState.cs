using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAirState : PlayerState
{
    public PlayerAirState(Player inputPlayer, PlayerStateMachine inputPlayerStateMachine, string inputAnimBoolName) : base(inputPlayer, inputPlayerStateMachine, inputAnimBoolName)
    {
    }
    public override void BeginState()
    {
        base.BeginState();
    }

    public override void UpdateState()
    {
        base.UpdateState();

        if (Mathf.Approximately(0, rb.velocity.y))
        {
            stateMachine.ChangeState(player.idleState);
        }

        if (horizontalInput != 0)
            player.SetVelocity(player.moveSpeed * 0.8f * horizontalInput, rb.velocity.y);
    }

    public override void EndState()
    {
        base.EndState();
    }
}