using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveState : EnemyOnTheGroundState
{
    public EnemyMoveState(Enemy inputEnemy, EnemyStateMachine inputEnemyStateMachine, string inputAnimBoolName) : base(inputEnemy, inputEnemyStateMachine, inputAnimBoolName)
    {
    }
    public override void BeginState()
    {
        base.BeginState();
    }

    public override void UpdateState()
    {
        base.UpdateState();

        if (enemy.IsWallDetected() || enemy.IsOnTheGround() == false)
        {
            enemy.Flip();
            stateMachine.ChangeState(enemy.idleState);
        }
        enemy.SetVelocity(enemy.moveSpeed * enemy.facingDirection, rb.velocity.y);
    }

    public override void EndState()
    {
        base.EndState();
    }


}