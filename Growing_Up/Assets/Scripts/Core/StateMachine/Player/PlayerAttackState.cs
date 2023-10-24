using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerState
{
    public PlayerAttackState(Player inputPlayer, PlayerStateMachine inputPlayerStateMachine, string inputAnimBoolName) : base(inputPlayer, inputPlayerStateMachine, inputAnimBoolName)
    {
    }
    public override void BeginState()
    {
        base.BeginState();
        player.animator.SetBool("Attack", true);
        float attackDirection = player.facingDirection;
        if (horizontalInput != 0)
            attackDirection = horizontalInput;
        player.SetVelocity(attackDirection, rb.velocity.y);
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
        player.StartCoroutine(nameof(player.BusyFor), 0.15f);
    }
}
