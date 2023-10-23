using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    public CapsuleCollider2D collider { get; private set; }

    public PlayerStateMachine stateMachine { get; private set; } 
    public PlayerIdleState idleState { get; private set; }
    public PlayerMoveState moveState { get; private set; }
    [Header("Movement info")]
    public float moveSpeed = 7f;
    
    protected override void Awake()
    {
        base.Awake();
        stateMachine = new PlayerStateMachine();
        idleState = new PlayerIdleState(this, stateMachine, "Idle");
        moveState = new PlayerMoveState(this, stateMachine, "Move");

    }

    protected override void Start()
    {
        base.Start();
        collider = GetComponent<CapsuleCollider2D>();
        stateMachine.Initialize(idleState);
    }
    protected override void Update()
    {
        base.Update();
        if (Time.timeScale == 0)
            return;
        stateMachine.currentState.UpdateState();
    }


}
