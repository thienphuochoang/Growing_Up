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
        if (Input.GetKey(KeyCode.A) && player.IsOnTheGround())
            stateMachine.ChangeState(player.attackState);
        if (Input.GetKeyDown(KeyCode.Space) && player.IsOnTheGround())
            stateMachine.ChangeState(player.jumpState);
        if (Input.GetKeyUp(KeyCode.F) && player.IsOnTheGround())
            player.ConsumePotion();
    }

    public override void EndState()
    {
        base.EndState();
    }
}