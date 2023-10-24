using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    [Header("Potion info")]
    [SerializeField]
    private int _numberOfPotion = 0;
    [Header("Attack check info")]
    public Transform attackCheck;
    public float attackCheckRadius;
    public CapsuleCollider2D col { get; private set; }

    public PlayerStateMachine stateMachine { get; private set; } 
    public PlayerIdleState idleState { get; private set; }
    public PlayerMoveState moveState { get; private set; }
    public PlayerAirState airState { get; private set; }
    public PlayerJumpState jumpState { get; private set; }
    public PlayerAttackState attackState { get; private set; }
    public PlayerDieState dieState { get; private set; }
    [Header("Movement info")]
    public float moveSpeed = 7f;
    public float jumpForce = 15f;
    public event System.Action OnNumberOfPotionChanged;
    public event System.Action OnPotionConsumed;
    public bool isBusy { get; private set; }
    protected override void Awake()
    {
        base.Awake();
        stateMachine = new PlayerStateMachine();
        idleState = new PlayerIdleState(this, stateMachine, "Idle");
        moveState = new PlayerMoveState(this, stateMachine, "Move");
        jumpState = new PlayerJumpState(this, stateMachine, "Jump");
        airState = new PlayerAirState(this, stateMachine, "Jump");
        attackState = new PlayerAttackState(this, stateMachine, "Attack");
        dieState = new PlayerDieState(this, stateMachine, "Die");
    }

    protected override void Start()
    {
        base.Start();
        col = GetComponent<CapsuleCollider2D>();
        stateMachine.Initialize(idleState);
        isDead = false;
    }
    protected override void Update()
    {
        base.Update();
        if (Time.timeScale == 0)
            return;
        if (GameManager.Instance.suddenDeath)
        {
            isDead = true;
        }
        if (isDead)
        {
            stateMachine.ChangeState(dieState);
        }
        stateMachine.currentState.UpdateState();
    }
    public void TriggerAnimation() => stateMachine.currentState.FinishAnimationTrigger();
    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.DrawWireSphere(attackCheck.position, attackCheckRadius);
    }

    public override void Die()
    {
        base.Die();
        isDead = true;
    }
    public void TriggerDeathAnimation()
    {
        Destroy(this.gameObject);
    }

    public void AddPotion(int amount)
    {
        _numberOfPotion += amount;
        OnNumberOfPotionChanged?.Invoke();
    }
    public void ConsumePotion()
    {
        if (_numberOfPotion > 0)
        {
            _numberOfPotion -= 1;
            OnNumberOfPotionChanged?.Invoke();
            OnPotionConsumed?.Invoke();
        }

    }
    public IEnumerator BusyFor(float seconds)
    {
        isBusy = true;
        yield return new WaitForSeconds(seconds);
        isBusy = false;
    }

    public int GetPotion() => _numberOfPotion;
}
