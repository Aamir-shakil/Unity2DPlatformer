using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("References")]
    public Rigidbody2D rb;

    [Header("Movement")]
    public float movementSpeed = 5f;
    public float speedMultiplier = 1f;
    private float horizontalMovement;
    private bool isFacingRight = true;

    [Header("Jumping")]
    public float jumpPower = 7f;
    public int maxJumps = 2;
    private int jumpsRemaining;

    [Header("GroundCheck")]
    public Transform groundCheckPos;
    public Vector2 groundCheckSize = new Vector2(0.5f, 0.05f);
    public LayerMask groundLayer;
    public bool IsGrounded { get; private set; }

    [Header("WallCheck")]
    public Transform wallCheckPos;
    public Vector2 wallCheckSize = new Vector2(0.5f, 0.05f);
    public LayerMask wallLayer;

    [Header("Wall Movement")]
    public float wallSlideSpeed = 2f;
    public Vector2 wallJumpPower = new Vector2(5f, 7f);
    public float wallJumpTime = 0.5f;

    private float wallJumpDirection;
    private float wallJumpTimer;
    public bool IsWallJumping { get; private set; }

    private Coroutine speedBoostRoutine;

    public PlayerStateMachine StateMachine { get; private set; }

    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }
    public PlayerAirState AirState { get; private set; }
    public PlayerWallSlideState WallSlideState { get; private set; }
    public PlayerWallJumpState WallJumpState { get; private set; }

    public float HorizontalMovement => horizontalMovement;

    private void Awake()
    {
        StateMachine = new PlayerStateMachine();

        IdleState = new PlayerIdleState(this);
        MoveState = new PlayerMoveState(this);
        AirState = new PlayerAirState(this);
        WallSlideState = new PlayerWallSlideState(this);
        WallJumpState = new PlayerWallJumpState(this);
    }

    private void Start()
    {
        jumpsRemaining = maxJumps;
        SpeedItem.OnSpeedCollected += StartSpeedBoost;
        StateMachine.Initialize(IdleState);
    }

    private void Update()
    {
        GroundCheck();
        UpdateWallJumpWindow();
        Flip();
        StateMachine.CurrentState.LogicUpdate();
    }

    private void UpdateWallJumpWindow()
    {
        if (!CanWallSlide() && wallJumpTimer > 0f)
        {
            wallJumpTimer -= Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }

    public void Move(InputAction.CallbackContext context)
    {
        horizontalMovement = context.ReadValue<Vector2>().x;
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            StateMachine.CurrentState.OnJumpPressed();
        }

        if (context.canceled)
        {
            StateMachine.CurrentState.OnJumpReleased();
        }
    }

    public void MoveHorizontally()
    {
        if (!IsWallJumping)
        {
            rb.linearVelocity = new Vector2(horizontalMovement * movementSpeed * speedMultiplier, rb.linearVelocity.y);
        }
    }

    public bool CanJump()
    {
        return jumpsRemaining > 0;
    }

    public void PerformJump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpPower);
        jumpsRemaining--;
    }

    public void CutJumpShort()
    {
        if (rb.linearVelocity.y > 0f)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f);
        }
    }

    public bool CanWallSlide()
    {
        return !IsGrounded && WallCheck() && rb.linearVelocity.y <= 0f;
    }

    public void ApplyWallSlide()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, Mathf.Max(rb.linearVelocity.y, -wallSlideSpeed));
    }

    public void StartWallJumpWindow()
    {
        IsWallJumping = false;
        wallJumpDirection = -transform.localScale.x;
        wallJumpTimer = wallJumpTime;

        CancelInvoke(nameof(CancelWallJump));
    }

    public bool CanWallJump()
    {
        return wallJumpTimer > 0f;
    }

    public void PerformWallJump()
    {
        IsWallJumping = true;
        wallJumpTimer = 0f;

        rb.linearVelocity = new Vector2(wallJumpDirection * wallJumpPower.x, wallJumpPower.y);

        if (transform.localScale.x != wallJumpDirection)
        {
            isFacingRight = !isFacingRight;
            Vector3 ls = transform.localScale;
            ls.x *= -1f;
            transform.localScale = ls;
        }

        Invoke(nameof(CancelWallJump), wallJumpTime + 0.1f);
    }



    private void CancelWallJump()
    {
        IsWallJumping = false;
    }

    private void GroundCheck()
    {
        IsGrounded = Physics2D.OverlapBox(groundCheckPos.position, groundCheckSize, 0, groundLayer);

        if (IsGrounded)
        {
            jumpsRemaining = maxJumps;
        }
    }

    private bool WallCheck()
    {
        return Physics2D.OverlapBox(wallCheckPos.position, wallCheckSize, 0, wallLayer);
    }

    private void Flip()
    {
        if ((isFacingRight && horizontalMovement < 0) || (!isFacingRight && horizontalMovement > 0))
        {
            isFacingRight = !isFacingRight;
            Vector3 ls = transform.localScale;
            ls.x *= -1f;
            transform.localScale = ls;
        }
    }

    private void StartSpeedBoost(float multiplier)
    {
        if (speedBoostRoutine != null)
        {
            StopCoroutine(speedBoostRoutine);
        }

        speedBoostRoutine = StartCoroutine(SpeedBoostCoroutine(multiplier));
    }

    private IEnumerator SpeedBoostCoroutine(float multiplier)
    {
        speedMultiplier = multiplier;
        yield return new WaitForSeconds(4f);
        speedMultiplier = 1f;
    }

    private void OnDestroy()
    {
        SpeedItem.OnSpeedCollected -= StartSpeedBoost;
    }

    private void OnDrawGizmosSelected()
    {
        if (groundCheckPos != null)
        {
            Gizmos.color = Color.white;
            Gizmos.DrawWireCube(groundCheckPos.position, groundCheckSize);
        }

        if (wallCheckPos != null)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireCube(wallCheckPos.position, wallCheckSize);
        }
    }
}