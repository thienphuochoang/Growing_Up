using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerOnTheGroundState
{
    public PlayerAttackState(Player inputPlayer, PlayerStateMachine inputPlayerStateMachine, string inputAnimBoolName) : base(inputPlayer, inputPlayerStateMachine, inputAnimBoolName)
    {
    }
    public override void BeginState()
    {
        base.BeginState();
        
        player.animator.SetBool("Attack", true);
        
        player.SetVelocity(player.facingDirection, rb.velocity.y);
        stateTimer = 0.1f;
    }

    public override void UpdateState()
    {
        base.UpdateState();
        if (stateTimer < 0)
            player.ResetVelocity();
        if (animationTriggerCalled)
            stateMachine.ChangeState(player.idleState);
    }

    public override void EndState()
    {
        base.EndState();
    }
}
