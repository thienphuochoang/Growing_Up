using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    protected Player _player;
    public EnemyStateMachine stateMachine { get; private set; }
    public BoxCollider2D col { get; private set; }
    [Header("Move info")]
    public float moveSpeed = 2f;
    public float idleTime = 2f;
    
    [Header("Battle info")]
    public float attackCooldown;
    [HideInInspector]
    public float lastTimeAttacked;
    public float battleTime;

    [Header("Enemy Detection View")]
    public float viewRadius = 10f;       // Radius of the field of view
    public float viewAngle = 90f;        // Half of the angle of the field of view
    public float detectionDistance = 5f;
    public float forgettingDistance = 15f;
    [SerializeField]
    private LayerMask playerLayerMask;

    public event System.Action OnFlipped;
    public bool IsWallDetected() => Physics2D.Raycast(wallCheck.position, Vector2.right * facingDirection, wallCheckDistance, groundLayerMask);
    public EnemyIdleState idleState { get; private set; }
    public EnemyMoveState moveState { get; private set; }
    public EnemyBattleState battleState { get; private set; }
    public EnemyAttackState attackState { get; private set; }
    protected override void Awake()
    {
        base.Awake();
        stateMachine = new EnemyStateMachine();
        idleState = new EnemyIdleState(this, stateMachine, "Idle");
        moveState = new EnemyMoveState(this, stateMachine, "Move");
        battleState = new EnemyBattleState(this, stateMachine, "Move");
        attackState = new EnemyAttackState(this, stateMachine, "Attack");
    }

    protected override void Start()
    {
        base.Start();
        _player = PlayerManager.Instance.player;
        col = GetComponent<BoxCollider2D>();
        stateMachine.Initialize(idleState);
    }

    protected override void Update()
    {
        base.Update();
        stateMachine.currentState.UpdateState();
    }

    public override void Flip()
    {
        base.Flip();
        OnFlipped?.Invoke();
    }
    
    public bool IsPlayerDetectedInHalfOfTheCircle()
    {
        Vector2 directionToPlayer = _player.transform.position - transform.position;
        float angleToPlayer = Vector2.Angle(transform.right, directionToPlayer);

        if (angleToPlayer <= viewAngle && directionToPlayer.magnitude <= viewRadius)
        {
            return true;
        }

        return false;
    }
    
    
    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.color = Color.red;
        Vector2 direction = Quaternion.Euler(0, 0, viewAngle) * transform.right;
        Gizmos.DrawRay(transform.position, direction * viewRadius);
        direction = Quaternion.Euler(0, 0, -viewAngle) * transform.right;
        Gizmos.DrawRay(transform.position, direction * viewRadius);
        Gizmos.DrawWireSphere(transform.position, viewRadius);
    }
    public void TriggerAttackAnimation()
    {
        //GameObject newBomb = Instantiate(_bombPrefab, _bombThrowingTransform.position, Quaternion.identity);
        //newBomb.GetComponent<BombProjectileController>().SetupProjectile(_player.transform.position, stats);
    }
}
