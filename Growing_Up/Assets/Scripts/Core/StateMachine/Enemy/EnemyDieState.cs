using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDieState : EnemyState
{
    public EnemyDieState(Enemy inputEnemy, EnemyStateMachine inputEnemyStateMachine, string inputAnimBoolName) : base(inputEnemy, inputEnemyStateMachine, inputAnimBoolName)
    {
    }
    public override void BeginState()
    {
        base.BeginState();
        rb.velocity = Vector2.zero;
        enemy.animator.SetBool("Die", true);
        stateTimer = 3f;
    }

    public override void UpdateState()
    {
        base.UpdateState();
        if (stateTimer < 0)
        {
            DestroySelf();
        }
    }

    public override void EndState()
    {
        base.EndState();
    }

    private void DestroySelf()
    {
        Object.Destroy(enemy.gameObject);
    }
}