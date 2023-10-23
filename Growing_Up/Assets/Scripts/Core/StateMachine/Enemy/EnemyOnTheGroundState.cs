using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOnTheGroundState : EnemyState
{
    protected Transform _player;

    public override void BeginState()
    {
        base.BeginState();
        _player = PlayerManager.Instance.player.transform;
    }

    public override void UpdateState()
    {
        base.UpdateState();
        if (enemy.IsPlayerDetectedInHalfOfTheCircle() || Vector2.Distance(enemy.transform.position, _player.transform.position) < enemy.detectionDistance)
            stateMachine.ChangeState(enemy.attackState);
    }

    public override void EndState()
    {
        base.EndState();
    }

    public EnemyOnTheGroundState(Enemy inputEnemy, EnemyStateMachine inputEnemyStateMachine, string inputAnimBoolName) : base(inputEnemy, inputEnemyStateMachine, inputAnimBoolName)
    {
    }
}