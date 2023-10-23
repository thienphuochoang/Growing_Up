using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState
{
    protected EnemyStateMachine stateMachine;
    protected Enemy enemy;
    protected Rigidbody2D rb;
    

    private string animBoolName;
    protected float stateTimer;
    protected bool animationTriggerCalled = false;

    public EnemyState(Enemy inputEnemy, EnemyStateMachine inputEnemyStateMachine, string inputAnimBoolName)
    {
        this.stateMachine = inputEnemyStateMachine;
        this.enemy = inputEnemy;
        this.animBoolName = inputAnimBoolName;
    }

    public virtual void BeginState()
    {
        rb = enemy.rb;
        enemy.animator.SetBool(animBoolName, true);
        animationTriggerCalled = false;
    }
    public virtual void UpdateState()
    {
        stateTimer -= Time.deltaTime;
    }
    public virtual void EndState()
    {
        enemy.animator.SetBool(animBoolName, false);
    }

    public virtual void FinishAnimationTrigger()
    {
        animationTriggerCalled = true;
    }
}