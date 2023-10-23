using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public Rigidbody2D rb { get; private set; }
    public Animator animator { get; private set; }
    public int facingDirection { get; private set; } = 1;
    private bool _isFacingRight = true;
    [Header("Collision")]
    [SerializeField]
    protected LayerMask groundLayerMask;
    [SerializeField]
    protected Transform groundCheck;
    [SerializeField]
    protected float groundCheckDistance = 1f;
    [SerializeField]
    protected Transform wallCheck;
    [SerializeField]
    protected float wallCheckDistance = 1f;
    public bool IsOnTheGround() =>Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, groundLayerMask);
    public bool IsWallDetected() => Physics2D.Raycast(wallCheck.position, Vector2.right * facingDirection, wallCheckDistance, groundLayerMask);

    protected virtual void Start()
    {
        rb = GetComponentInChildren<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }
    protected virtual void Update()
    {

    }

    protected virtual void Awake()
    {
        
    }

    public virtual void Flip()
    {
        facingDirection *= -1;
        _isFacingRight = !_isFacingRight;
        transform.Rotate(0, 180, 0);
    }
    public void ControlFlip(float horizontalVelocity)
    {
        if (horizontalVelocity > 0 && !_isFacingRight)
            Flip();
        else if (horizontalVelocity < 0 && _isFacingRight)
            Flip();
    }

    
    public void SetVelocity(float horizontalVelocity, float verticalVelocity)
    {
        rb.velocity = new Vector2(horizontalVelocity, verticalVelocity);
        ControlFlip(horizontalVelocity);
    }

    public void ResetVelocity()
    {
        rb.velocity = Vector2.zero;
    }
    protected virtual void OnDrawGizmos()
    {
        if (groundCheck || wallCheck)
        {
            Gizmos.DrawLine(groundCheck.position, new Vector3(groundCheck.position.x, groundCheck.position.y - groundCheckDistance));
            Gizmos.DrawLine(wallCheck.position, new Vector3(wallCheck.position.x + wallCheckDistance, wallCheck.position.y));
        }
    }
}
