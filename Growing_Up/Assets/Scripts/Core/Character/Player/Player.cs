using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    public CapsuleCollider2D col { get; private set; }

    public PlayerStateMachine stateMachine { get; private set; } 
    public PlayerIdleState idleState { get; private set; }
    public PlayerMoveState moveState { get; private set; }
    public PlayerAirState airState { get; private set; }
    public PlayerJumpState jumpState { get; private set; }
    public PlayerAttackState attackState { get; private set; }
    [Header("Movement info")]
    public float moveSpeed = 7f;
    public float jumpForce = 15f;
    protected override void Awake()
    {
        base.Awake();
        stateMachine = new PlayerStateMachine();
        idleState = new PlayerIdleState(this, stateMachine, "Idle");
        moveState = new PlayerMoveState(this, stateMachine, "Move");
        jumpState = new PlayerJumpState(this, stateMachine, "Jump");
        airState = new PlayerAirState(this, stateMachine, "Jump");
        attackState = new PlayerAttackState(this, stateMachine, "Attack");
    }

    protected override void Start()
    {
        base.Start();
        col = GetComponent<CapsuleCollider2D>();
        stateMachine.Initialize(idleState);
    }
    protected override void Update()
    {
        base.Update();
        if (Time.timeScale == 0)
            return;
        stateMachine.currentState.UpdateState();
    }
    public void TriggerAnimation() => stateMachine.currentState.FinishAnimationTrigger();

}
