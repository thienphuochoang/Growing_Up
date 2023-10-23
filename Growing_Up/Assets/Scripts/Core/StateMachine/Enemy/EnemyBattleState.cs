using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class EnemyBattleState : EnemyState
{
    private Transform _player;
    private int _moveDirection;

    public EnemyBattleState(Enemy inputEnemy, EnemyStateMachine inputEnemyStateMachine, string inputAnimBoolName) : base(inputEnemy, inputEnemyStateMachine, inputAnimBoolName)
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

        if (enemy.IsPlayerDetectedInHalfOfTheCircle())
        {
            stateTimer = enemy.battleTime;
            if (CanAttack())
            {
                stateMachine.ChangeState(enemy.attackState);
            }
        }
        else
        {
            if (stateTimer < 0 || Vector2.Distance(_player.transform.position, enemy.transform.position) > enemy.forgettingDistance)
                stateMachine.ChangeState(enemy.idleState);
        }

        if (_player.position.x > enemy.transform.position.x && enemy.facingDirection == -1)
            enemy.Flip();
        else if (_player.position.x < enemy.transform.position.x && enemy.facingDirection == 1)
            enemy.Flip();
        enemy.ResetVelocity();
    }

    public override void EndState()
    {
        base.EndState();
    }

    private bool CanAttack()
    {
        if (Time.time >= enemy.lastTimeAttacked + enemy.attackCooldown)
        {
            enemy.lastTimeAttacked = Time.time;
            return true;
        }

        return false;
    }


}
