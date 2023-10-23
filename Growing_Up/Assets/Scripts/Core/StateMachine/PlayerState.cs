using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    protected PlayerStateMachine stateMachine;
    protected Player player;
    protected Rigidbody2D rb;
    
    protected float horizontalInput;
    protected float verticalInput;
    private string animBoolName;
    protected float stateTimer;
    protected bool animationTriggerCalled = false;

    public PlayerState(Player inputPlayer, PlayerStateMachine inputPlayerStateMachine, string inputAnimBoolName)
    {
        this.stateMachine = inputPlayerStateMachine;
        this.player = inputPlayer;
        this.animBoolName = inputAnimBoolName;
    }

    public virtual void BeginState()
    {
        player.animator.SetBool(animBoolName, true);
        rb = player.rb;
        animationTriggerCalled = false;
    }
    public virtual void UpdateState()
    {
        stateTimer -= Time.deltaTime;
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        player.animator.SetFloat("VerticalVelocity", rb.velocity.y);
    }
    public virtual void EndState()
    {
        player.animator.SetBool(animBoolName, false);
    }

    public virtual void FinishAnimationTrigger()
    {
        animationTriggerCalled = true;
    }
}
