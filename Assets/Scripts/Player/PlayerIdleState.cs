using UnityEngine;

public class PlayerIdleState : IPlayerState
{
    private readonly PlayerMovement player;

    public PlayerIdleState(PlayerMovement player)
    {
        this.player = player;
    }

    public void Enter()
    {
    }

    public void Exit()
    {
    }

    public void LogicUpdate()
    {
        if (!player.IsGrounded)
        {
            player.StateMachine.ChangeState(player.AirState);
            return;
        }

        if (Mathf.Abs(player.HorizontalMovement) > 0.01f)
        {
            player.StateMachine.ChangeState(player.MoveState);
            return;
        }

        if (player.CanWallSlide())
        {
            player.StateMachine.ChangeState(player.WallSlideState);
        }
    }

    public void PhysicsUpdate()
    {
        player.MoveHorizontally();
    }

    public void OnJumpPressed()
    {
        if (player.CanJump())
        {
            player.PerformJump();
            player.StateMachine.ChangeState(player.AirState);
        }
    }

    public void OnJumpReleased()
    {
        player.CutJumpShort();
    }
}