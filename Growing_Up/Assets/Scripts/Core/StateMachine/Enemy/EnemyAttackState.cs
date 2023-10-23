using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyState
{
    private Transform _player;
    public EnemyAttackState(Enemy inputEnemy, EnemyStateMachine inputEnemyStateMachine, string inputAnimBoolName) : base(inputEnemy, inputEnemyStateMachine, inputAnimBoolName)
    {
    }
    public override void BeginState()
    {
        base.BeginState();
        _player = PlayerManager.Instance.player.transform;
    }

    public override void UpdateState()
    {
        base.UpdateState();
        enemy.ResetVelocity();
        if (animationTriggerCalled)
        {
            stateMachine.ChangeState(enemy.battleState);
        }
    }

    public override void EndState()
    {
        base.EndState();
        enemy.lastTimeAttacked = Time.time;
    }


}