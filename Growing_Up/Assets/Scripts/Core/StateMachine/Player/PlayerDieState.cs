using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDieState : PlayerState
{
    public PlayerDieState(Player inputPlayer, PlayerStateMachine inputPlayerStateMachine, string inputAnimBoolName) : base(inputPlayer, inputPlayerStateMachine, inputAnimBoolName)
    {
    }
    public override void BeginState()
    {
        base.BeginState();
        player.animator.SetBool("Die", true);
    }

    public override void UpdateState()
    {
        base.UpdateState();
        player.ResetVelocity();
    }

    public override void EndState()
    {
        base.EndState();
    }


}