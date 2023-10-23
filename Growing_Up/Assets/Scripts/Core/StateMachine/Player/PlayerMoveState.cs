using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerOnTheGroundState
{
    
    public PlayerMoveState(Player inputPlayer, PlayerStateMachine inputPlayerStateMachine, string inputAnimBoolName) : base(inputPlayer, inputPlayerStateMachine, inputAnimBoolName)
    {
    }

    public override void BeginState()
    {
        base.BeginState();
    }

    public override void UpdateState()
    {
        base.UpdateState();
        player.SetVelocity(horizontalInput * player.moveSpeed, rb.velocity.y);
        //Debug.Log(rb.velocity);
        if (Mathf.Approximately(0, rb.velocity.x))
        {
            stateMachine.ChangeState(player.idleState);
        }
        
        if (rb.velocity.y < -0.01)
            stateMachine.ChangeState(player.airState);
            
    }
}