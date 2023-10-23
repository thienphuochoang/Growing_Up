using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyOnTheGroundState
{
    public EnemyIdleState(Enemy inputEnemy, EnemyStateMachine inputEnemyStateMachine, string inputAnimBoolName) : base(inputEnemy, inputEnemyStateMachine, inputAnimBoolName)
    {
    }
    public override void BeginState()
    {
        base.BeginState();
        stateTimer = enemy.idleTime;
    }

    public override void UpdateState()
    {
        base.UpdateState();
        if (stateTimer < 0)
            stateMachine.ChangeState(enemy.moveState);
    }

    public override void EndState()
    {
        base.EndState();
    }


}