using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class PlayerOnTheGroundState : PlayerState
{
    public PlayerOnTheGroundState(Player inputPlayer, PlayerStateMachine inputPlayerStateMachine, string inputAnimBoolName) : base(inputPlayer, inputPlayerStateMachine, inputAnimBoolName)
    {
    }

    public override void UpdateState()
    {
        base.UpdateState();
        if (Input.GetKey(KeyCode.A))
            stateMachine.ChangeState(player.attackState);
        if (Input.GetKeyDown(KeyCode.Space) && player.IsOnTheGround())
            stateMachine.ChangeState(player.jumpState);
    }

    public override void EndState()
    {
        base.EndState();
    }
}